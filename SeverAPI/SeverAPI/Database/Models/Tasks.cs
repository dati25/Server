using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models;

[Table("tbTasks")]
public class Tasks : IModel
{
    [JsonIgnore] public int Id { get; set; }
    public int IdPc { get; set; }
    [JsonIgnore] public int IdConfig { get; set; }
    public string? Snapshot { get; set; }
    public Tasks(int idPc, int idConfig)
    {
        IdPc = idPc;
        IdConfig = idConfig;
    }
}