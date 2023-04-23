using Server.Database.Models;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Google.Protobuf;

namespace Server.Commands.AdminCommands
{
    public class AdminTestCommands : ICommand
    {
        public Dictionary<string, List<string>> CheckAll(Admin admin)
        {
            Dictionary<string, List<string>> expections = new Dictionary<string, List<string>>();
            if (!this.tester.CheckExistence(admin))
                return this.tester.AddOrApend(expections, "Admin: ", "doesn't exist");

            this.tester.IsLongerThan(expections, "Username", admin.Username, 3);
            this.tester.IsLongerThan(expections, "Password", admin.Password, 3);
            this.tester.NoSpecialChars(expections, "Username", admin.Username);
            this.IsValidEmail(expections, "Email", admin.Email);
                this.tester.TestCronExpression(expections, "RepeatPeriod", admin.RepeatPeriod!);
            return expections;
        }
        public Dictionary<string, List<string>> IsValidEmail(Dictionary<string, List<string>> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$", "format isn't valid");
        }
        public string SerializeDic(Dictionary<string, List<string>> dic)
        {
            return JsonConvert.SerializeObject(dic);
        }
    }
}
