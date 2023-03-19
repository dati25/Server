using SeverAPI.Database.Models;

namespace SeverAPI.Results.AdminResults
{
    public class AdminResultGet : IModel
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        //public string ProfilePicture { get; set; }
        public string RepeatPeriod { get; set; }

        public AdminResultGet(Admin admin)
        {
            this.id = admin.id;
            this.Username = admin.Username;
            this.Email = admin.Email;
            this.RepeatPeriod = admin.RepeatPeriod;
        }
    }
}
