using SeverAPI.Commands.TestingCommands;
using SeverAPI.Database.Models;
using System.Runtime.InteropServices;

namespace SeverAPI.Commands.AdminCommands
{
    public class AdminTestCommands : ICommand
    {
        public void CheckAll(Admin admin)
        {
            if (admin == null)
                throw new ArgumentNullException("Admin doesn't exist.");

            TestingString[] testStrings = { new TestingString("Username", admin.Username), new TestingString("Password", admin.Password) };


            var arguments = this.tester.NoSpecialLetters(testStrings[0].Value);
            if (!arguments.Item1)
                throw new Exception($"{testStrings[arguments.Item2].ParamName} cannot contain any special characters.");

            int lenght = 3;
            arguments = this.tester.IsLongerThan(lenght, testStrings[0].Value, testStrings[1].Value);
            if (!arguments.Item1)
                throw new Exception($"{testStrings[arguments.Item2].ParamName} must be longer than {lenght}.");

            if (!this.tester.IsValidEmail(admin.Email))
                throw new Exception("The email adress isn't valid.");
        }


    }
}
