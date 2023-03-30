using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models;

[Table("tbPcGroups")]
[PrimaryKey("IdPc","IdGroup")]
public class PcGroups : IModel
{
    public int IdPc { get; set; }
    [JsonIgnore] public int IdGroup { get; set; }
    public PcGroups(int idPc, int idGroup)
    {
        IdPc = idPc;
        IdGroup = idGroup;
    }
}