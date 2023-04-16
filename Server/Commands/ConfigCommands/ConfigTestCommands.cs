using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Server.Database.Models;
using Server.Results.ConfigResults;
using Server.Results.SourceResults;
using Server.Results.TaskResults;

namespace Server.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandTest config, int? idConfig)
        {
            Dictionary<string, List<string>> exceptions = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(exceptions, "Config", "doesn't exist");

            if (context.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(exceptions, "CreatedBy", "Admin doesn't exist");

            this.IsValidType(exceptions, "Status", config.Type);

            if (config.RepeatPeriod != null)
                this.tester.TestCronExpression(exceptions, "RepeatPeriod", config.RepeatPeriod);

            if (config.Sources!.Count > 0)
            {
                for (int i = 0; i < config.Sources!.Count; i++)
                {
                    this.IsValidFilePath(exceptions, $"Source({i + 1})", config.Sources[i].Path);
                }
            }
            if (config.Destinations!.Count > 0)
            {
                for (int i = 0; i < config.Destinations!.Count; i++)
                {
                    this.IsValidFilePath(exceptions, $"Destination({i})", config.Destinations[i].Path);
                }
            }
            if (config.Groups!.Count > 0)
            {
                List<int> idPCs = new List<int>();
                //for (int i = 0; i < config.Groups!.Count; i++)
                //{
                //    idPCs.AddRange(this.AddPCs(config.Groups[i]));
                //}
                config.Groups!.ForEach(group => idPCs.AddRange(this.AddPCs(group)));
                if (idConfig != null)
                    context.Tasks!.Where(task => task.IdConfig == idConfig).ToList().ForEach(task => idPCs.AddRange(this.AddPCs(task.IdGroup)));
                if (config.Computers!.Count > 0)
                    config.Computers.ForEach(x => idPCs.Add(x));

                if (idPCs.Distinct().Count() != idPCs.Count())
                {
                    this.tester.AddOrApend(exceptions, "Task", "There is one or more computers assigned to one config twice");
                }

            }
            return exceptions;
        }
        public Dictionary<string, List<string>> CheckConfig(Config config, int idConfig)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config);
            return this.CheckConfig(configCommand, idConfig);
        }
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandPost config)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config);
            return this.CheckConfig(configCommand, null);
        }
        public Dictionary<string, List<string>> IsValidFilePath(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"@""(^[a-zA-Z]:[\\\/]{1,2}$)|(^([a-zA-Z]:([\\\/]{1,2}[^\\\/:\*\?""""<>\|]+)+)$)", "path is not valid");
        }
        public Dictionary<string, List<string>> IsValidType(Dictionary<string, List<string>> dic, string key, string value)
        {
            if (!(value == "full" || value == "incr" || value == "diff"))
            {
                return this.tester.AddOrApend(dic, key, "must be either \"full\",\"diff\" or \"incr\"");
            }
            return dic;
        }
        public Dictionary<string, List<string>> CheckDestination(Dictionary<string, List<string>> dic, string key, string value, bool type)
        {
            if (type)
            {
                ConfigFTP ftp = JsonConvert.DeserializeObject<ConfigFTP>(value)!;

                this.tester.NoSpecialChars(dic, key, ftp.Username);
                this.tester.IsValid(dic, key, ftp.Host, @"^((https://)?((www\.)?[\w\-]+(\.[\w\-]+)+)$", "Host adress ins't valid");

                return dic;
            }
            return this.IsValidFilePath(dic, key, value);

        }
        private Dictionary<string, List<string>> FTPCheckPort(Dictionary<string, List<string>> dic, int port)
        {
            List<int> defaultPorts = new List<int>() { 20, 21, 22, 443, 990 };

            if (!(defaultPorts.Any(x => x == port) || (port > 49152 && port < 65535)))
                return this.tester.AddOrApend(dic, "path", "incorrect port");

            return dic;
        }
        private List<int> AddPCs(int groupId)
        {
            List<int> list = new List<int>();
            Server.Database.Models.Group group = context.Groups!.Find(groupId)!;
            group.PcGroups = context.PcGroups!.Where(x => x.IdGroup == groupId).ToList();
            group.PcGroups!.ForEach(pcGroup => list.Add(pcGroup.IdPc));
            return list;
        }
    }
}
