using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models;

[Table("tbTasks")]
[PrimaryKey("IdPc","IdConfig")]
public class Tasks : IModel
{
    public int IdPc { get; set; }
    [JsonIgnore] public int IdConfig { get; set; }
    public string? Snapshot { get; set; }
    public Tasks(int idPc, int idConfig)
    {
        IdPc = idPc;
        IdConfig = idConfig;
    }
}