using SeverAPI.Database.Models;

namespace SeverAPI.Commands.GroupCommands
{
    public class GroupCommandDelete : Command
    {
        public Group Execute(int id)
        {
            Group? group = context.Groups!.Find(id);

            if (group == null)
                return null!;

            context.Groups.Remove(group);
            context.SaveChanges();

            return group;
        }

        public Group DeletePCGroups(int id, int pcGroupID)
        {
            Group? group = context.Groups!.Find(id);
            PCGroups? pcGroup = context.PCGroups!.Find(pcGroupID);

            if (group == null || pcGroup == null)
                return null!;

            group.PCGroups!.Remove(pcGroup);
            context.SaveChanges();

            return group;
        }
    }
}
