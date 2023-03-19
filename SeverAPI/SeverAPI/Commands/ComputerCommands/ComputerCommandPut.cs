using SeverAPI.Database.Models;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerCommandPut : Command
    {
        public string? name { get; set; }
        public string? macAddress { get; set; }
        public string? iPAddress { get; set; }
        public bool? status { get; set; }

        public ComputerCommandPut(string? name, string? macAddress, string? ipAddress, bool? status)
        {
            this.name = name;
            this.macAddress = macAddress;
            this.iPAddress = ipAddress;
            this.status = status;
        }

        public Computer Execute(int id)
        {
            Computer? computer = context.Computers.Find(id);

            if (computer == null)
                return null!;

            computer.Name = name ?? computer.Name;
            computer.MacAddress = macAddress ?? computer.MacAddress;
            computer.IPAddress = iPAddress ?? computer.IPAddress;
            computer.Status = status ?? computer.Status;

            context.SaveChanges();

            return computer;
        }
    }
}
