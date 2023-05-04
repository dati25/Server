using System;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using Server.Database.Models;
using Server.Results.ConfigResults;


namespace Server.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandTest config, MyContext myContext, int? idConfig)
        {
            Dictionary<string, List<string>> exceptions = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(exceptions, "Config", "doesn't exist");

            if (myContext.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(exceptions, "CreatedBy", "Admin doesn't exist");

            this.IsValidType(exceptions, "Status", config.Type);

            if (config.RepeatPeriod != null)
                this.tester.TestCronExpression(exceptions, "RepeatPeriod", config.RepeatPeriod);

            if (config.Sources != null)
            {
                for (int i = 0; i < config.Sources!.Count; i++)
                {
                    this.tester.IsValidFilePath(exceptions, $"Source({i + 1})", config.Sources[i].Path);
                }
            }
            if (config.Destinations! != null)
            {
                for (int i = 0; i < config.Destinations!.Count; i++)
                {
                    //if (config.Destinations[i].Type == false)
                    //{
                    //    this.IsValidFilePath(exceptions, $"Destination({i})", config.Destinations[i].Path);
                    //    continue;
                    //}
                    this.CheckDestination(exceptions, $"Destination({i})", config.Destinations[i].Path, config.Destinations[i].Type);
                }
            }
            if (config.Groups != null)
                this.CheckGroups(exceptions, config, idConfig);

            if (config.Computers!.Any(x => myContext.Computers!.Find(x) == null))
                this.tester.AddOrApend(exceptions, "Computers", "One of the computers doesn't exist");

            return exceptions;
        }
        public Dictionary<string, List<string>> CheckConfig(Config config, MyContext myContext, int idConfig)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config, myContext);
            return this.CheckConfig(configCommand, myContext, idConfig);
        }
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandPost config, MyContext myContext)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config);
            return this.CheckConfig(configCommand, myContext, null);
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
                this.tester.TestFtpConfig(dic, key, value);

                return dic;
            }
            return this.tester.IsValidFilePath(dic, key, value);

        }
        private List<int> AddPCs(int groupId)
        {
            List<int> list = new List<int>();
            Server.Database.Models.Group group = context.Groups!.Find(groupId)!;
            group.PcGroups = context.PcGroups!.Where(x => x.IdGroup == groupId).ToList();
            group.PcGroups!.ForEach(pcGroup => list.Add(pcGroup.IdPc));
            return list;
        }
        private Dictionary<string, List<string>> CheckGroups(Dictionary<string, List<string>> dic, ConfigCommandTest config, int? configId)
        {
            bool next = true;

            List<Server.Database.Models.Group> groups = new List<Server.Database.Models.Group>();

            config.Groups!.ForEach(groupId => groups.AddRange(context.Groups!.Where(group => group.Id == groupId)));

            for (int i = 0; i < groups.Count; i++)
                if (groups[i].Name.StartsWith("pc_"))
                {
                    this.tester.AddOrApend(dic, $"Group({groups[i].Id})", "Group doesn't exist");
                    next = false;
                }
            if (next)
                this.CheckDuplicatePCs(dic, config, configId);
            return dic;
        }
        private Dictionary<string, List<string>> CheckDuplicatePCs(Dictionary<string, List<string>> dic, ConfigCommandTest config, int? idConfig)
        {
            List<int> idPCs = new List<int>();

            config.Groups!.ForEach(group => idPCs.AddRange(this.AddPCs(group)));
            if (idConfig != null)
                context.Tasks!.Where(task => task.IdConfig == idConfig).ToList().ForEach(task => idPCs.AddRange(this.AddPCs(task.IdGroup)));
            if (config.Computers!.Count > 0)
                config.Computers.ForEach(x => idPCs.Add(x));

            if (idPCs.Distinct().Count() != idPCs.Count())
            {
                this.tester.AddOrApend(dic, "Task", "There is one or more computers assigned to one config twice");
            }
            return dic;
        }
    }
}
