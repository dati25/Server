using SeverAPI.Results.GroupResults;
using SeverAPI.Database.Models;

namespace SeverAPI.Commands.GroupCommands
{
    public class GroupCommandSearchedGet : Command
    {
        public GroupResultGet Execute(int id)
        {
            Group? group = context.Groups!.Find(id);

            if (group == null)
                return null!;

            GroupResultGet result = new GroupResultGet(group);

            return result;
        }
    }
}
