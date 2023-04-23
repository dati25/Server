using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models;

[Table("tbPCs")]
public class Computer : IModel
{
    public int Id { get; set; }
    public string MacAddress { get; set; }
    public string IpAddress { get; set; }
    public string Name { get; set; }
    public char Status { get; set; }
    public List<Snapshots>? Snapshots { get; set; }

    public Computer(string macAddress, string ipAddress, string name, char status = 'q')
    {
        MacAddress = macAddress;
        IpAddress = ipAddress;
        Name = name;
        Status = status;
    }
}