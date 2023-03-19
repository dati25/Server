using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandSearchedGet : Command
    {
        public AdminResultGet Execute(int id)
        {
            if (context.Admins.Find(id) == null)
                return null!;

            Admin? admin = context.Admins.Find(id);

            return new AdminResultGet(admin!);
        }
    }
}
