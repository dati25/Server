﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SeverAPI.Commands
{
    public class Tester
    {
        public bool CheckExistence<T>(T tested)
        {
            return tested != null;
        }
        public Dictionary<string, string> AddOrApend(Dictionary<string, string> dic, string key, string errorMessage)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] += ", " + errorMessage;
                return dic;
            }
            dic.Add(key, errorMessage);
            return dic;
        }
        public Dictionary<string, string> IsValid(Dictionary<string, string> dic, string key, string value, string regexPattern, string message)
        {
            if (!Regex.IsMatch(value, regexPattern))
                return this.AddOrApend(dic, key, message);
            return dic;
        }
        public Dictionary<string, string> IsLongerThan(Dictionary<string,string> dic, string key, string value, int mustBeLonger)
        {
            if (mustBeLonger >= value.Length)
                return this.AddOrApend(dic, key, $"must be longer than {mustBeLonger} characters");
            return dic;
        }
        public Dictionary<string,string> NoSpecialChars(Dictionary<string, string> dic, string key, string value)
        {
            return IsValid(dic, key, value, @"^[a-zA-Z0-9\-_]*$", "cannot contain any special characters");
        }
        public Dictionary<string, string> TestCronExpression(Dictionary<string, string> dic, string key, string value)
        {
            return IsValid(dic, key, value, @"^((\d+,)*\d+|(\d+(\/|-)\d+)|\*|\*\/\d+|\d+(\/|-)\*|\?)( ((\d+,)*\d+|(\d+(\/|-)\d+)|\*|\*\/\d+|\d+(\/|-)\*|\?)){4}$", "cron value not valid");
        }
    }
}
