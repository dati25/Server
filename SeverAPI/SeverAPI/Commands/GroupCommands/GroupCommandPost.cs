using SeverAPI.Database.Models;
using SeverAPI.Results.PCGroupResults;

namespace SeverAPI.Commands.GroupCommands
{
    public class GroupCommandPost : ICommand
    {
        public string Name { get; set; }
        public List<PCGroupResultPost>? PCGroups { get; set; }

        public GroupCommandPost(string name, List<PCGroupResultPost>? pcGroups)
        {
            Name = name;
            PCGroups = pcGroups;
        }

        public Group Execute()
        {
            Group group = new Group(Name);

            context.Groups!.Add(group);
            context.SaveChanges();

            foreach (var item in PCGroups!)
                context.PCGroups!.Add(new PCGroups(item.idPC, group.id));

            context.SaveChanges();
            return group;
        }
    }
}
