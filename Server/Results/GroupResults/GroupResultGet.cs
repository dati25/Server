using Server.Results.PcGroupResults;
using Server.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Results.GroupResults;

public class GroupResultGet
{
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("IdGroup")] public List<PcGroupResultGet> PcGroups { get; set; } = new List<PcGroupResultGet>();
    MyContext context = new MyContext();

    public GroupResultGet(Group group)
    {
        Id = group.Id;
        Name = group.Name;
        context.PcGroups!.Where(x => x.IdGroup == group.Id).ToList().ForEach(x => PcGroups.Add(new PcGroupResultGet(x)));
    }
}