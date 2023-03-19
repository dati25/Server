using SeverAPI.Database.Models;
using SeverAPI.Results.ComputerResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPost : Command
    {
        public ComputerResultPost Execute(ComputerResultPost computer)
        {
            if (!(IsValidIP(computer.IPAddress)) || !(IsValidMac(computer.MacAddress)))
                return null!;

            this.context.Add(new Computer(computer.Name, computer.MacAddress, computer.IPAddress, computer.Status));
            this.context.SaveChanges();

            return computer;
        }

        public bool IsValidIP(string ipAddress)
        {
            string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
            return Regex.IsMatch(ipAddress, pattern);
        }

        public bool IsValidMac(string macAddress)
        {
            string pattern = @"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
            return Regex.IsMatch(macAddress, pattern);
        }
    }
}
