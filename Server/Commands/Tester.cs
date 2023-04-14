﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Org.BouncyCastle.Bcpg;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Server.Commands
{
    public class Tester
    {
        public bool CheckExistence<T>(T tested)
        {
            return tested != null;
        }
        public Dictionary<string, List<string>> AddOrApend(Dictionary<string, List<string>> dic, string key, string errorMessage)
        {
            if (dic.ContainsKey(key))
            {
                dic[key].Add(errorMessage);
                return dic;
            }
            dic.Add(key, new List<string>() { errorMessage });
            return dic;
        }
        public Dictionary<string, List<string>> IsValid(Dictionary<string, List<string>> dic, string key, string value, string regexPattern, string message)
        {
            if (!Regex.IsMatch(value, regexPattern))
                return this.AddOrApend(dic, key, message);
            return dic;
        }
        public Dictionary<string, List<string>> IsLongerThan(Dictionary<string, List<string>> dic, string key, string value, int mustBeLonger)
        {
            if (mustBeLonger >= value.Length)
                return this.AddOrApend(dic, key, $"must be longer than {mustBeLonger} characters");
            return dic;
        }
        public Dictionary<string, List<string>> NoSpecialChars(Dictionary<string, List<string>> dic, string key, string value)
        {
            return IsValid(dic, key, value, @"^[a-zA-Z0-9\-_]*$", "cannot contain any special characters");
        }
        public Dictionary<string, List<string>> TestCronExpression(Dictionary<string, List<string>> dic, string key, string value)
        {
            CronExpression cron = new CronExpression();
            return cron.TestCronExpression(dic, key, value);
        }
        public class CronExpression
        {
            private Tester tester = new Tester();
            private string regexPattern = @"^(?<minute>((\d{1,2},)*\d{1,2}|(\d{1,2}(\/|-)\d{1,2})|\*|\*\/\d{1,2}|\d{1,2}(\/|-)\*|\?)) (?<hour>((\d{1,2},)*\d{1,2}|(\d{1,2}(\/|-)\d{1,2})|\*|\*\/\d{1,2}|\d{1,2}(\/|-)\*|\?)) (?<dayMonth>((\d{1,2},)*\d{1,2}|(\d{1,2}(\/|-)\d{1,2})|\*|\*\/\d{1,2}|\d{1,2}(\/|-)\*|\?)) (?<month>((\d{1,2},)*\d{1,2}|(\d{1,2}(\/|-)\d{1,2})|\*|\*\/\d{1,2}|\d{1,2}(\/|-)\*|\?)) (?<dayWeek>((\d{1,2},)*\d{1,2}|(\d{1,2}(\/|-)\d{1,2})|\*|\*\/\d{1,2}|\d{1,2}(\/|-)\*|\?))$";
            private bool failed = false;
            public Dictionary<string, List<string>> TestCronExpression(Dictionary<string, List<string>> dic, string key, string value)
            {
                Match col = Regex.Match(value, this.regexPattern);

                if (!col.Success)
                    return this.tester.AddOrApend(dic, key, "cron format is not valid");

                this.ValuesCheck(dic, key, col.Groups["minute"].Value, 59, "minute", true, false);
                this.ValuesCheck(dic, key, col.Groups["hour"].Value, 23, "hour", true, false);
                //this.ValuesCheck(dic, key, col.Groups["dayWeek"].Value, 59, "day(week)", false, false);
                this.ValuesCheck(dic, key, col.Groups["month"].Value, 12, "month", false, true);
                if (!failed)
                    this.DayMonthCheck(dic, key, col.Groups["dayMonth"].Value, col.Groups["month"].Value, "day(month)");

                return dic;
            }
            public Dictionary<string, List<string>> ValuesCheck(Dictionary<string, List<string>> dic, string key, string value, int highestValue, string valueType, bool canBeZero, bool monthCheck)
            {
                if (value == "*")
                    return dic;

                List<int> ints = new List<int>();
                int i = canBeZero ? 1 : 0;
                value.Split('-', '/', ',').ToList().ForEach(x => ints.Add(int.Parse(x)));

                if (ints.Count > 1 && (ints[0] < ints[1] && value.Contains('-')))
                {
                    this.tester.AddOrApend(dic, key, $"{valueType}: first throught value cannot be smaller than the second");
                    this.failed = true;
                }

                foreach (var item in ints)
                {
                    if (item > highestValue || (!canBeZero && item < 1))
                    {
                        tester.AddOrApend(dic, key, $"{valueType}: value must be between {i}-{highestValue}");
                        if (monthCheck)
                            this.failed = true;
                    }
                }
                if (ints.Distinct().Count() == ints.Count() && value.Contains(","))
                {
                    tester.AddOrApend(dic, key, $"{valueType}: there are duplicate values");
                }
                return dic;
            }
            public Dictionary<string, List<string>> DayMonthCheck(Dictionary<string, List<string>> dic, string key, string value, string month, string valueType)
            {
                if (value == "*")
                    return dic;
                int highestDayCount = 0;
                List<int> months = new List<int>();

                month.Split('-', '/', ',').ToList().ForEach(x => months.Add(int.Parse(x)));
                int[] dayCount = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                if (months.Count == 2 && month.Contains('-'))
                {
                    for (int i = months[0]; i <= months[1]; i++)
                        highestDayCount = Math.Max(highestDayCount, dayCount[i]);
                }
                else if (months.Count == 2 && month.Contains('/'))
                {
                    for (int i = month[0]; i <= dayCount.Length; i += month[1])
                    {
                        highestDayCount = Math.Max(highestDayCount, dayCount[i]);
                    }
                }
                else if (months.Count > 1 && month.Contains(','))
                    months.ForEach(x => highestDayCount = Math.Max(highestDayCount, dayCount[x]));
                else
                {
                    highestDayCount = month[months[0]];
                }

                this.ValuesCheck(dic, key, value, highestDayCount, value, false, false);
                return dic;
            }
        }
    }
}