using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResult
    {
        public int id { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public int? idConfig { get; set; }

        public ComputerResult(Computer computer, int? idConfig)
        {
            id = computer.id;
            MacAddress = computer.MacAddress;
            IPAddress = computer.IPAddress;
            Name = computer.Name;
            Status = computer.Status;

            this.idConfig = idConfig;
        }
    }
}