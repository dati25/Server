using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbPC")]
    public class Computer : IModel
    {
        public int id { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public char Status { get; set; }
        public string? Name { get; set; }

        public Computer(string macAddress, string iPAddress, char status = 'q', string? name = null)
        {
            MacAddress = macAddress;
            IPAddress = iPAddress;
            Status = status;
            Name = name;
        }
    }
}
