using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPut : ICommand
    {
        public string? macAddress { get; set; }
        public string? iPAddress { get; set; }
        public char? status { get; set; }
        public string? name { get; set; }

        public ComputerCommandPut(string? macAddress, string? ipAddress, char? status, string? name)
        {
            this.macAddress = macAddress;
            this.iPAddress = ipAddress;
            this.status = status;
            this.name = name;
        }

        public Computer Execute(int id)
        {
            Computer? computer = context.Computers!.Find(id);

            if (computer == null)
                return null!;

            computer.MacAddress = macAddress ?? computer.MacAddress;
            computer.IPAddress = iPAddress ?? computer.IPAddress;
            computer.Status = status ?? computer.Status;
            computer.Name = name ?? computer.Name;

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
