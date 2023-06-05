using Server.Database.Models;
using System.Text.RegularExpressions;

namespace Server.Commands.AdminCommands;

public class AdminCommandPut
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? RepeatPeriod { get; set; }

    public AdminCommandPut(string? username, string? password, string? email, string? repeatPeriod)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.RepeatPeriod = repeatPeriod;
    }
    public Admin? Execute(int id, MyContext context)
    {
        AdminTestCommands tests = new AdminTestCommands();
        Admin? admin = context.Admins!.Find(id);
        var tester = new Tester();

        admin!.Username = this.Username ?? admin.Username;
        admin.Password = this.Password != null ? BCrypt.Net.BCrypt.EnhancedHashPassword(this.Password, workFactor: 13) : admin.Password;
        admin.Email = this.Email ?? admin.Email;
        admin.RepeatPeriod = this.RepeatPeriod != null ? tester.QuestionMarkChange(this.RepeatPeriod) : admin.RepeatPeriod;


        return admin!;
    }

    public bool IsValidEmail(string emailAddress)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
        return Regex.IsMatch(emailAddress, pattern);
    }
}