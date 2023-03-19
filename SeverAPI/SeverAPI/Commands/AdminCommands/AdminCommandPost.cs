using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandPost : Command
    {
        public AdminResultPost Execute(AdminResultPost admin)
        {
            this.context.Add(new Admin(admin.Username, admin.Password, admin.Email));
            this.context.SaveChanges();

            return admin;
        }

    }
}
