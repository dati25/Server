using SeverAPI.Commands.TestingCommands;
using SeverAPI.Database.Models;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands.ComputerCommands
{
    public class ComputerTestCommands : ICommand
    {
        public void CheckAll(Computer computer)
        {
            if (computer == null)
                throw new ArgumentNullException("Computer doesn't exist.");

            TestingString[] testStrings = { new TestingString("Name", computer.Name) };

            var arguments = this.tester.NoSpecialLetters(testStrings[0].Value);
            if (!arguments.Item1)
                throw new Exception($"{testStrings[arguments.Item2].ParamName} cannot contain any special characters.");

            if (!IsValidMac(computer.MacAddress))
                throw new Exception("Invalid MacAdress.");

            if (!IsValidIp(computer.IpAddress))
                throw new Exception("Invalid IPAdress");

            if (!IsValidStatus(computer.Status))
                throw new Exception("Invalid Status");
        }

        public bool IsValidMac(string macAddress)
        {   
            string pattern = @"^[0-9a-f]{12}$";
            return Regex.IsMatch(macAddress.ToLower().Replace("-", string.Empty).Replace(":", string.Empty), pattern);
        }

        public bool IsValidIp(string ipAddress)
        {
            string pattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$";
            return Regex.IsMatch(ipAddress, pattern);
        }

        public bool IsValidStatus(char? c)
        {
            return c == 't' || c == 'f' || c == 'q';
        }

    }
}
