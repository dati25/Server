using SeverAPI.Database.Models;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandDelete : Command
    {

        public void Execute(int id)
        {
            Admin? admin = context.Admins.Find(id);

            if (admin == null)
                return;

            context.Admins.Remove(admin!);
            context.SaveChanges();
        }
    }
}
