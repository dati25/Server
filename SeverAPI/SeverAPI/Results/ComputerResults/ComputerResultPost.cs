using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResultPost
    {
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public char Status { get; set; }
        public string? Name { get; set; }

        public ComputerResultPost(string macAddress, string iPAddress, char Status = 'q', string? Name = null)
        {
            this.MacAddress = macAddress;
            this.IPAddress = iPAddress;
            this.Status = Status;
            this.Name = Name;
        }
    }
}
