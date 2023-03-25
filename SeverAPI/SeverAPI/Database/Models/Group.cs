using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models;

[Table("tbGroups")]
public class Group : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("idGroup")] public List<PcGroups>? PcGroups { get; set; }

    public Group(string name)
    {
        Name = name;
    }
}