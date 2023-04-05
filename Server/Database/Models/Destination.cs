using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Database.Models;

[Table("tbDestinations")]
public class Destination : IModel
{
    [JsonIgnore] public int Id { get; set; }
    [JsonIgnore] public int? IdConfig { get; set; }
    public bool Type { get; set; } // False - FileSystem; True - FTP server
    public string Path { get; set; }

    public Destination(int? idConfig, bool type, string path)
    {
        IdConfig = idConfig;
        Type = type;
        Path = path;
    }

}