using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Database.Models;

[Table("tbTasks")]
[PrimaryKey("IdGroup", "IdConfig")]
public class Tasks : IModel
{
    public int IdGroup { get; set; }
    [JsonIgnore] 
    public int IdConfig { get; set; }
    public Tasks(int idGroup, int idConfig)
    {
        this.IdGroup = idGroup;
        this.IdConfig = idConfig;
    }
}