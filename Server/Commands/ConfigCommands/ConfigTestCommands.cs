using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Server.Database.Models;
using Server.Results.ConfigResults;
using Server.Results.SourceResults;

namespace Server.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandTest config)
        {
            Dictionary<string, List<string>> exceptions = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(exceptions, "Config", "doesn't exist");

            if (context.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(exceptions, "CreatedBy", "Admin doesn't exist");

            this.IsValidType(exceptions, "Status", config.Type);

            if (config.RepeatPeriod != null)
                this.tester.TestCronExpression(exceptions, "RepeatPeriod", config.RepeatPeriod);

            if (config.Sources != null)
            {
                for (int i = 0; i < config.Sources!.Count; i++)
                {
                    this.IsValidFilePath(exceptions, $"Source({i+1})", config.Sources[i].Path);
                }
            }
            if (config.Destinations != null)
            {
                for (int i = 0; i < config.Destinations!.Count; i++)
                {
                    this.IsValidFilePath(exceptions, $"Destination({i})", config.Destinations[i].Path);
                }
            }
            return exceptions;
        }
        public Dictionary<string, List<string>> CheckConfig(Config config)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config);
            return this.CheckConfig(configCommand);
        }
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandPost config)
        {
            ConfigCommandTest configCommand = new ConfigCommandTest(config);
            return this.CheckConfig(configCommand);
        }
        public Dictionary<string, List<string>> IsValidFilePath(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"@""(^[a-zA-Z]:[\\\/]{1,2}$)|(^([a-zA-Z]:([\\\/]{1,2}[^\\\/:\*\?""""<>\|]+)+)$)", "path is not valid");
        }
        public Dictionary<string, List<string>> IsValidType(Dictionary<string, List<string>> dic, string key, string value)
        {
            if (!(value == "full" || value == "incr" || value == "incr"))
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
    }
}
