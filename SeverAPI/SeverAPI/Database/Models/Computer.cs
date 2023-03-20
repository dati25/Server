using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbPC")]
    public class Computer : IModel
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public bool? Status { get; set; }

        public Computer(string? name, string macAddress, string iPAddress, bool? status)
        {
            Name = name;
            MacAddress = macAddress;
            IPAddress = iPAddress;
            Status = status;
        }
    }
}
