using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandPost : ICommand
    {
        public AdminResultPost Execute(AdminResultPost admin)
        {
            this.context.Add(new Admin(admin.Username, admin.Password, admin.Email, null));
            this.context.SaveChanges();

            return admin;
        }

        public bool IsValidEmail(string emailAddress)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
            return Regex.IsMatch(emailAddress, pattern);
        }
    }
}
