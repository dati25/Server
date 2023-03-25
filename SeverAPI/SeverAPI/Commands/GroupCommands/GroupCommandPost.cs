using SeverAPI.Database.Models;
using SeverAPI.Results.PcGroupResults;

namespace SeverAPI.Commands.GroupCommands;

public class GroupCommandPost : ICommand
{
    public string Name { get; set; }
    public List<PcGroupResultPost>? PcGroups { get; set; }

    public GroupCommandPost(string name, List<PcGroupResultPost>? pcGroups)
    {
        Name = name;
        PcGroups = pcGroups;
    }

    public Group Execute()
    {
        Group group = new Group(Name);

        context.Groups!.Add(group);
        context.SaveChanges();

        foreach (var item in PcGroups!)
            context.PcGroups!.Add(new PcGroups(item.IdPc, group.Id));

        context.SaveChanges();
        return group;
    }
}