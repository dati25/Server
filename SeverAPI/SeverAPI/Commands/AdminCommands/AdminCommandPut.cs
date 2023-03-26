using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.AdminCommands;

public class AdminCommandPut : ICommand
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? RepeatPeriod { get; set; }

    public AdminCommandPut(string? username, string? password, string? email, string? repeatPeriod)
    {
        Username = username;
        Password = password;
        Email = email;
        RepeatPeriod = repeatPeriod;
    }
    public Admin? Execute(int id)
    {
        AdminTestCommands tests = new AdminTestCommands();
        Admin? admin = context.Admins!.Find(id);

        this.tester.CheckExistence(admin!);

        admin.Username = Username ?? admin.Username;
        admin.Password = Password ?? admin.Password;
        admin.Email = Email ?? admin.Email;
        admin.RepeatPeriod = RepeatPeriod ?? admin.RepeatPeriod;

        tests.CheckAll(admin);

        context.SaveChanges();
        return admin;
    }

    public bool IsValidEmail(string emailAddress)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
        return Regex.IsMatch(emailAddress, pattern);
    }
}