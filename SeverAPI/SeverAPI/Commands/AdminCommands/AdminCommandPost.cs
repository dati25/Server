using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.AdminCommands;

public class AdminCommandPost : ICommand
{
    public AdminResultPost? Execute(AdminResultPost admin)
    {
        if (!IsValidEmail(admin.Email))
            return null;

        context.Add(new Admin(admin.Username, admin.Password, admin.Email, null));
        context.SaveChanges();

        return admin;
    }

    public bool IsValidEmail(string emailAddress)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
        return Regex.IsMatch(emailAddress, pattern);
    }
}