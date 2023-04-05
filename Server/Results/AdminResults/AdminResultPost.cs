namespace Server.Results.AdminResults;

public class AdminResultPost
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public AdminResultPost(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}