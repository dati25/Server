using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models;

[Table("tbPcGroups")]
public class PcGroups : IModel
{
    public int Id { get; set; }
    public int IdPc { get; set; }
    public int IdGroup { get; set; }

    public PcGroups(int idPc, int idGroup)
    {
        IdPc = idPc;
        IdGroup = idGroup;
    }
}