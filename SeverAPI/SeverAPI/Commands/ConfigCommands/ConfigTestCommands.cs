using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ConfigCommands
{
    public class ConfigTestCommands : ICommand
    {



        public Dictionary<string, string> IsValidFilePath(Dictionary<string,string> dic, string key, string value)
        {
            Regex.IsMatch(value.Trim(), @"^[a-zA-Z@""^[a-zA-Z]:([\\\/]|\\\\)(?:[^\\\/:*?""""<>|]+([\\\/]|\\\\))*[^\\\/:*?""""<>|]*$");
            return this.tester.IsValid(dic, key, value, @"^[a-zA-Z@""^[a-zA-Z]:([\\\/]|\\\\)(?:[^\\\/:*?""""<>|]+([\\\/]|\\\\))*[^\\\/:*?""""<>|]*$", "path is not valid");
        }
        public Dictionary<string, string> IsValidStatus(Dictionary<string, string> dic, string key, string value)
        {
            if(!(value == "full" || value == "incr" || value == "incr"))
            {
                return this.tester.AddOrApend(dic, key, "must be either \"full\",\"diff\" or \"incr\"");
            }
            return dic;
        }
    }
}
