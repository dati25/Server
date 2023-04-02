using SeverAPI.Commands.TestingCommands;
using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerTestCommands : ICommand
    {
        public Dictionary<string, string> CheckAll(Computer computer)
        {
            Dictionary<string, string> expections = new Dictionary<string, string>(); 
            if (!this.tester.CheckExistence(computer))
                return this.tester.AddOrApend(expections, "Computer: ", "doesn't exist");

            this.tester.IsLongerThan(expections, "Name", computer.Name, 3);
            this.IsValidMac(expections, "MacAdress", computer.MacAddress);
            this.IsValidIp(expections, "IPAdress", computer.IpAddress);
            this.IsValidStatus(expections, "Status", computer.Status);
            return expections;
        }
        public Dictionary<string, string> IsValidMac(Dictionary<string, string> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value.ToLower().Replace("-", string.Empty).Replace(":", string.Empty), @"^[0-9a-f]{12}$", "format isn't valid");
        }
        public Dictionary<string, string> IsValidIp(Dictionary<string, string> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$", "format isn't valid");
        }
        public Dictionary<string, string> IsValidStatus(Dictionary<string, string> dic, string key, char? value)
        {
            if (!(value == 't' || value == 'f' || value == 'q'))
            {
                return this.tester.AddOrApend(dic, key, "must be either't' - true, 'f' - false or 'q' - waiting for approval");
            }
            return dic;
        }
    }
}
