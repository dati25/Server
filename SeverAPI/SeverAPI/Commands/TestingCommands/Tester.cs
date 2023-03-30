using System.Text.RegularExpressions;

namespace SeverAPI.Commands.TestingCommands
{
    public class Tester 
    {

        public bool IsValidEmail(string emailAddress)
        {
            string pattern = @"^[\w-\.]+@([\w-]+\.)*[\w-]+\.[\w-]{2,4}$";
            return Regex.IsMatch(emailAddress, pattern);
        }
        public Tuple<bool, int> MyAny<T>(Func<T, bool> func, params T[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!func(s[i]))
                    return Tuple.Create(false, i);
            }
            return Tuple.Create(true, 0);
        }
        public Tuple<bool, int> NoSpecialLetters(params string[] strings)
        {
            return MyAny(x => Regex.IsMatch(x, @"^[a-zA-Z0-9\-_]*$"), strings);
        }
        public Tuple<bool, int> IsLongerThan(int mustBeLonger, params string[] strings)
        {
            return MyAny(x => x.Length > mustBeLonger, strings);
        }
        public void CheckExistence<T>(T tested) where T : class
        {
            if (tested == null)
                throw new ArgumentNullException("Object doesn't exist.");
        }
        //public Dictionary<string, string> IsLongerThan(Dictionary<string,string> dic,int mustBeLonger, string s, string paramname)
        //{



        //}
    }
}
