using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models
{
    [Table("tbPC")]
    public class Computer : IModel
    {
        public int id { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string? Name { get; set; }
        public char Status { get; set; }

        public Computer(string macAddress, string iPAddress, string? name = null, char status = 'q')
        {
            MacAddress = macAddress;
            IPAddress = iPAddress;
            Name = name;
            Status = status;
        }
    }
}
