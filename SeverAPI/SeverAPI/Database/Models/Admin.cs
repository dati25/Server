using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SeverAPI.Database.Models;

[Table("tbAdmins")]
public class Admin : IModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public string Email { get; set; }
    public string? RepeatPeriod { get; set; } // Null = monthly

    public Admin(string username, string password, string email, string? repeatPeriod)
    {
        Username = username;
        Password = password;
        Email = email;
        RepeatPeriod = repeatPeriod ?? "0 0 1 * *";
    }
}