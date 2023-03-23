using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResultGet
    {
        public int id { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string? Name { get; set; }
        public char Status { get; set; }

        public ComputerResultGet(Computer computer)
        {
            id = computer.id;
            MacAddress = computer.MacAddress;
            IPAddress = computer.IPAddress;
            Name = computer.Name;
            Status = computer.Status;
        }
    }
}
