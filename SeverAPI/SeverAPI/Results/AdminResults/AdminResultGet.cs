using SeverAPI.Database.Models;

namespace SeverAPI.Results.AdminResults
{
    public class AdminResultGet
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? RepeatPeriod { get; set; }

        public AdminResultGet(Admin? admin)
        {
            id = admin!.id;
            Username = admin.Username;
            Email = admin.Email;
            RepeatPeriod = admin.RepeatPeriod;
        }
    }
}
