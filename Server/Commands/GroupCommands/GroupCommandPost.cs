using Server.Database.Models;
using Server.Results.PcGroupResults;

namespace Server.Commands.GroupCommands;

public class GroupCommandPost : ICommand
{
    public string Name { get; set; }
    public List<PCGroupResultPut>? PcGroups { get; set; }

    public GroupCommandPost(string name, List<PCGroupResultPut>? pcGroups)
    {
        Name = name;
        PcGroups = pcGroups;
    }

    public Group Execute()
    {
        Group group = new Group(Name);

        context.Groups!.Add(group);
        context.SaveChanges();

        if (PcGroups != null)
        {
            foreach (var item in PcGroups!)
                context.PcGroups!.Add(new PcGroups(item.IdPc, group.Id));
        }

        context.SaveChanges();
        return group;
    }
}