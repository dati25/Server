using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResultPost
    {
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }

        public ComputerResultPost(string macAddress, string iPAddress, string? Name = null, bool? Status = null)
        {
            this.MacAddress = macAddress;
            this.IPAddress = iPAddress;
        }
    }
}
