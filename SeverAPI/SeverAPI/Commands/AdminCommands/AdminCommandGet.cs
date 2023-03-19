using SeverAPI.Results.AdminResults;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandGet : Command
    {
        public List<AdminResultGet> Execute(int? inputCount, int offset = 0)
        {
            List<AdminResultGet>? adminsList = new List<AdminResultGet>();
            context.Admins.ToList().ForEach(x => adminsList.Add(new AdminResultGet(x)));

            if (inputCount == null && offset == 0)
                return adminsList;

            int count = inputCount ?? adminsList.Count;
            if (count <= 0 || offset > adminsList.Count)
                return null!;

            count = this.CheckCount(adminsList, count);
            List<AdminResultGet>? ResultAdmin = new List<AdminResultGet>();

            for (int i = offset; i < count; i++)
                ResultAdmin.Add(adminsList[i]);

            return ResultAdmin!;
        }
        public int CheckCount<T>(List<T> list, int count)
        {
            if (list.Count <= count)
                return list.Count;

            return count;
        }
    }
}
