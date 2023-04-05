using Server.Database.Models;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
namespace Server.Commands.AdminCommands
{
    public class AdminTestCommands : ICommand
    {
        //public void CheckAll(Admin admin)
        //{
        //    if (admin == null)
        //        throw new ArgumentNullException("Admin doesn't exist.");

        //    TestingString[] testStrings = { new TestingString("Username", admin.Username), new TestingString("Password", admin.Password) };


        //    var arguments = this.tester.NoSpecialLettersTuple(testStrings[0].Value);
        //    if (!arguments.Item1)
        //        throw new Exception($"{testStrings[arguments.Item2].ParamName} cannot contain any special characters.");

        //    int lenght = 3;
        //    arguments = this.tester.IsLongerThan(lenght, testStrings[0].Value, testStrings[1].Value);
        //    if (!arguments.Item1)
        //        throw new Exception($"{testStrings[arguments.Item2].ParamName} must be longer than {lenght}.");

        //    //if (!this.tester.IsValidEmail(admin.Email))
        //    //    throw new Exception("The email adress isn't valid.");
        //}
        public Dictionary<string, string> CheckAll(Admin admin)
        {
            Dictionary<string, string> expections = new Dictionary<string, string>();
            if (!this.tester.CheckExistence(admin))
                return this.tester.AddOrApend(expections, "Admin: ", "doesn't exist");

            this.tester.IsLongerThan(expections, "Username", admin.Username, 3);
            this.tester.IsLongerThan(expections, "Password", admin.Password, 3);
            this.tester.NoSpecialChars(expections, "Username", admin.Username);
            this.IsValidEmail(expections, "Email", admin.Email);
            return expections;
        }
        public Dictionary<string, string> IsValidEmail(Dictionary<string, string> dic, string key, string value)
        {
            return this.tester.IsValid(dic, key, value, @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$", "format isn't valid");
        }
        public string SerializeDic(Dictionary<string, string> dic)
        {
            return JsonConvert.SerializeObject(dic);
        }
    }
}
