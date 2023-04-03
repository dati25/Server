using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using SeverAPI.Database.Models;
using SeverAPI.Results.SourceResults;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {
        public Dictionary<string, string> CheckConfig(ConfigCommandPost config)
        {
            Dictionary<string, string> expections = new Dictionary<string, string>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(expections, "Config: ", "doesn't exist");

            if (context.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(expections, "CreatedBy: ", "Admin doesn't exist");

            if (config.Sources != null)
            {
                for (int i = 0; i < config.Sources!.Count; i++)
                {
                    this.IsValidFilePath(expections, $"Source({config.Sources[i]}.)", config.Sources[i].Path);
                }
            }
            if (config.Destinations != null)
            {
                for (int i = 0; i < config.Destinations!.Count; i++)
                {
                    this.IsValidFilePath(expections, $"Destination({config.Destinations[i]}.)", config.Destinations[i].Path);
                }
            }
            return expections;
        }
        public Dictionary<string, string> CheckConfig(Config config)
        {
            Dictionary<string, string> expections = new Dictionary<string, string>();
            if (!this.tester.CheckExistence(config))
                this.tester.AddOrApend(expections, "Config: ", "doesn't exist");

            if (context.Admins!.Find(config.CreatedBy) == null)
                this.tester.AddOrApend(expections, "CreatedBy: ", "Admin doesn't exist");
            
            if (config.Sources != null)
            {
                for (int i = 0; i < config.Sources!.Count; i++)
                {
                    this.IsValidFilePath(expections, $"Source({config.Sources[i]}.)", config.Sources[i].Path);
                }
            }
            if (config.Destinations != null)
            {
                for (int i = 0; i < config.Destinations!.Count; i++)
                {
                    this.IsValidFilePath(expections, $"Destination({config.Destinations[i]}.)", config.Destinations[i].Path);
                }
            }
            return expections;
        }
        public Dictionary<string, string> IsValidFilePath(Dictionary<string, string> dic, string key, string value)
        {
            Regex.IsMatch(value.Trim(), @"^[a-zA-Z@""^[a-zA-Z]:([\\\/]|\\\\)(?:[^\\\/:*?""""<>|]+([\\\/]|\\\\))*[^\\\/:*?""""<>|]*$");
            return this.tester.IsValid(dic, key, value, @"^[a-zA-Z@""^[a-zA-Z]:([\\\/]|\\\\)(?:[^\\\/:*?""""<>|]+([\\\/]|\\\\))*[^\\\/:*?""""<>|]*$", "path is not valid");
        }
        public Dictionary<string, string> IsValidStatus(Dictionary<string, string> dic, string key, string value)
        {
            if (!(value == "full" || value == "incr" || value == "incr"))
            {
                return this.tester.AddOrApend(dic, key, "must be either \"full\",\"diff\" or \"incr\"");
            }
            return dic;
        }
        public Dictionary<string, string> CheckDestination(Dictionary<string, string> dic, string key, string value, bool type)
        {
            if (type)
            {
                return dic;
            }
            return this.IsValidFilePath(dic, key, value);

        }
    }
}
