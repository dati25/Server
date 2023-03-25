using System.ComponentModel.DataAnnotations.Schema;

namespace SeverAPI.Database.Models;

[Table("tbAdmins")]
public class Admin : IModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string? RepeatPeriod { get; set; }

    public Admin(string username, string password, string email, string? repeatPeriod)
    {
        Username = username;
        Password = password;
        Email = email;
        RepeatPeriod = repeatPeriod;
    }
}