using SeverAPI.Database.Models;

namespace SeverAPI.Commands.GroupCommands
{
    public class GroupCommandPut : ICommand
    {
        public string? Name { get; set; }
        public List<PCGroups>? PCGroups { get; set; }

        public Group Execute(int id)
        {
            Group? group = context.Groups!.Find(id);

            if (group == null)
                return null!;

            group.Name = Name ?? group.Name;
            group.PCGroups = PCGroups ?? group.PCGroups;

            context.SaveChanges();

            return group;
        }
    }
}
