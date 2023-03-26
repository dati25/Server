using SeverAPI.Database.Models;
using SeverAPI.Results.AdminResults;
using System.Text.RegularExpressions;
using SeverAPI.Commands.TestingCommands;

namespace SeverAPI.Commands.AdminCommands;

public class AdminCommandPost : ICommand
{
    public Admin? Execute(AdminResultPost adminPost)
    {
        AdminTestCommands tests = new AdminTestCommands();
        Admin admin = new Admin(adminPost.Username, adminPost.Password, adminPost.Email, null);
        
        tests.CheckAll(admin);

        
        context.Add(admin);
        context.SaveChanges();

        return admin;
    }


}