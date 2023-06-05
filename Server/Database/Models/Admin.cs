using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Database.Models;

[Table("tbAdmins")]
public class Admin : IModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    [JsonIgnore] public string Password { get; set; }
    public string Email { get; set; }
    public string? RepeatPeriod { get; set; } // Null = monthly
    public DateTime? LastEmail { get; set; }
    public Admin(string username, string password, string email, string? repeatPeriod, DateTime? LastEmail)
    {
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.RepeatPeriod = repeatPeriod ?? "0 0 1 * ?";
        this.LastEmail = LastEmail;
    }
}