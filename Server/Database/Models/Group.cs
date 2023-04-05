using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Database.Models;

[Table("tbGroups")]
public class Group : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("IdGroup")] public List<PcGroups>? PcGroups { get; set; }

    public Group(string name)
    {
        Name = name;
    }
}