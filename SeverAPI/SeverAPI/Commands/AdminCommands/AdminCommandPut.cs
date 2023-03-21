using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.AdminsCommands
{
    public class AdminCommandPut : ICommand
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? repeatPeriod { get; set; }

        public AdminCommandPut(string? username, string? password, string? email, string? repeatPeriod)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.repeatPeriod = repeatPeriod;
        }
        public Admin Execute(int id)
        {
            Admin? admin = context.Admins!.Find(id);

            if (admin == null)
                return null!;

            admin.Username = username ?? admin.Username;
            admin.Password = password ?? admin.Password;
            admin.Email = email ?? admin.Email;
            admin.RepeatPeriod = repeatPeriod ?? admin.RepeatPeriod;

            if (!(IsValidEmail(admin.Email)) && admin.Email != null)
                return null!;

            context.SaveChanges();

            return admin;
        }

        public bool IsValidEmail(string emailAddress)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
            return Regex.IsMatch(emailAddress, pattern);
        }
    }
}
