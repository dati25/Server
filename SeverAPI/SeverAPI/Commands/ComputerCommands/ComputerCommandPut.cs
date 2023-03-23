using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPut : ICommand
    {
        public string? name { get; set; }
        public string? macAddress { get; set; }
        public string? iPAddress { get; set; }
        public char? status { get; set; }

        public ComputerCommandPut(string? name, string? macAddress, string? ipAddress, char? status)
        {
            this.name = name;
            this.macAddress = macAddress;
            this.iPAddress = ipAddress;
            this.status = status;
        }

        public Computer Execute(int id)
        {
            Computer? computer = context.Computers!.Find(id);

            if (computer == null)
                return null!;

            computer.Name = name ?? computer.Name;
            computer.MacAddress = macAddress ?? computer.MacAddress;
            computer.IPAddress = iPAddress ?? computer.IPAddress;
            computer.Status = status ?? computer.Status;

            if (!(IsValidIP(computer.IPAddress)) && computer.IPAddress != null)
                return null!;

            if (!(IsValidMac(computer.MacAddress)) && computer.MacAddress != null)
                return null!;

            context.SaveChanges();

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
