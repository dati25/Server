using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Database.Models;

[Table("tbPCGroups")]
[PrimaryKey("IdPc", "IdGroup")]
public class PcGroups : IModel
{
    public string IdPc { get; set; }
    [JsonIgnore] public int IdGroup { get; set; }
    public PcGroups(string idPc, int idGroup)
    {
        IdPc = idPc;
        IdGroup = idGroup;
    }
}