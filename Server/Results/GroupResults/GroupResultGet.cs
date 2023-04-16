using Server.Results.PcGroupResults;
using Server.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Results.TaskResults;

namespace Server.Results.GroupResults;

public class GroupResultGet
{
    public string Name { get; set; }
    [ForeignKey("IdGroup")] public List<PcGroupResultGet> Computers { get; set; } = new List<PcGroupResultGet>();
    public GroupResultGet(Group group, MyContext context)
    {
        this.Name = group.Name;
        context.PcGroups!.Where(x => x.IdGroup == group.Id).ToList().ForEach(x => Computers.Add(new PcGroupResultGet(x)));
    }
}