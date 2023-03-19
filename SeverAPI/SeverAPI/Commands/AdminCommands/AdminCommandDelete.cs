using SeverAPI.Database.Models;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandDelete : Command
    {

        public Admin Execute(int id)
        {
            Admin? admin = context.Admins.Find(id);

            if (admin == null)
                return null!;

            context.Admins.Remove(admin!);
            context.SaveChanges();

            return admin;
        }
    }
}
