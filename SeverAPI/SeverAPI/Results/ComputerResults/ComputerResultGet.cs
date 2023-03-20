using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResultGet
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public bool? Status { get; set; }

        public ComputerResultGet(Computer computer)
        {
            id = computer.id;
            Name = computer.Name;
            MacAddress = computer.MacAddress;
            IPAddress = computer.IPAddress;
            Status = computer.Status;
        }
    }
}
