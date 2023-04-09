using Server.Database.Models;
using System.Text.RegularExpressions;

namespace Server.Commands.ComputerCommands
{
    public class ComputerTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckAll(Computer computer)
        {
            Dictionary<string, List<string>> exceptions = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(computer))
                return this.tester.AddOrApend(exceptions, "Computer: ", "doesn't exist");

            this.tester.IsLongerThan(exceptions, "Name", computer.Name, 3);
            this.IsValidMac(exceptions, "MacAdress", computer.MacAddress);
            this.IsValidIp(exceptions, "IPAdress", computer.IpAddress);
            this.IsValidStatus(exceptions, "Status", computer.Status);
            return exceptions;
        }
        public Dictionary<string, List<string>> IsValidMac(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value.ToLower().Replace("-", string.Empty).Replace(":", string.Empty), @"^[0-9a-f]{12}$", "format isn't valid");
        }
        public Dictionary<string, List<string>> IsValidIp(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$", "format isn't valid");
        }
        public Dictionary<string, List<string>> IsValidStatus(Dictionary<string, List<string>> dic, string key, char? value)
        {
            if (!(value == 't' || value == 'f' || value == 'q'))
            {
                return this.tester.AddOrApend(dic, key, "must be either't' - true, 'f' - false or 'q' - waiting for approval");
            }
            return dic;
        }
    }
}
