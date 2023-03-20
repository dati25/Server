using SeverAPI.Database.Models;

namespace SeverAPI.Results.ComputerResults
{
    public class ComputerResultPost
    {
        public string Name { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public bool Status { get; set; }

        public ComputerResultPost(string name, string macAddress, string iPAddress, bool status)
        {
            this.Name = name;
            this.MacAddress = macAddress;
            this.IPAddress = iPAddress;
            this.Status = status;
        }
    }
}
