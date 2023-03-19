using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandSearchedGet : Command
    {
        public AdminResultGet Execute(int id)
        {
            Admin admin = context.Admins.Find(id);

            if (admin == null)
                return null;

            AdminResultGet adminResult = new AdminResultGet(admin);

            return adminResult;

            return new AdminResultGet(admin!);
        }
    }
}
