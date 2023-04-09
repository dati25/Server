using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Server.Database.Models;
using Server.Results.SourceResults;

namespace Server.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckConfig(ConfigCommandPost config)
        {
            Dictionary<string, List<string>> exceptions = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(exceptions, "Config", "doesn't exist");

            if (context.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(exceptions, "CreatedBy", "Admin doesn't exist");

            if (config.RepeatPeriod != null)
                this.tester.TestCronExpression(exceptions, "RepeatPeriod", config.RepeatPeriod);

            if (config.Sources != null)
            {
                for (int i = 1; i <= config.Sources!.Count; i++)
                {
                    this.IsValidFilePath(exceptions, $"Source({i})", config.Sources[i].Path);
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
            ConfigCommandPost configCommand = new ConfigCommandPost(config);
            return this.CheckConfig(configCommand);
        }
        public Dictionary<string, List<string>> IsValidFilePath(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"@""(^[a-zA-Z]:[\\\/]{1,2}$)|(^([a-zA-Z]:([\\\/]{1,2}[^\\\/:\*\?""""<>\|]+)+)$)", "path is not valid");
        }
        public Dictionary<string, List<string>> IsValidStatus(Dictionary<string, List<string>> dic, string key, string value)
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
                return dic;
            }
            return this.IsValidFilePath(dic, key, value);

        }
    }
}
