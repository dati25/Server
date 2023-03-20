using SeverAPI.Results.GroupResults;

namespace SeverAPI.Commands.GroupCommands
{
    public class GroupCommandGet : Command
    {
        public List<GroupResultGet> Execute(int? inputCount, int offset = 0)
        {
            List<GroupResultGet>? groupsList = new List<GroupResultGet>();
            context.Groups!.ToList().ForEach(x => groupsList.Add(new GroupResultGet(x)));

            if (inputCount == null && offset == 0)
                return groupsList;

            int count = inputCount ?? groupsList.Count;
            if (count <= 0 || offset >= groupsList.Count)
                return null!;

            count = this.CheckCount(groupsList, count);
            List<GroupResultGet>? ResultGroup = new List<GroupResultGet>();

            for (int i = offset; i < count; i++)
                ResultGroup.Add(groupsList[i]);

            return ResultGroup!;
        }

        public int CheckCount<T>(List<T> list, int count)
        {
            if (list.Count <= count)
                return list.Count;

            return count;
        }
    }
}
