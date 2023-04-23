namespace Server.Results.LoginServices
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Login(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
