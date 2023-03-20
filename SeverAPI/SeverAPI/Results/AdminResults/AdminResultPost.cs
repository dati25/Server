using SeverAPI.Database.Models;

namespace SeverAPI.Results.AdminResults
{
    public class AdminResultPost
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AdminResultPost(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}
