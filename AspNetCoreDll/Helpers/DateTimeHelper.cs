using AspNetCoreDll.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreDll.Helpers
{
    public class DateTimeHelper
    {
        public DateTimeHelper()
        {
        }

        public static DateTime EndOfDay()
        {
            return DateTimeHelper.EndOfDay(SystemTime.Now);
        }

        public static DateTime EndOfDay(DateTime dateTime)
        {
            return DateTimeHelper.EndOfDay(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime EndOfDay(int year, int month, int day)
        {
            return new DateTime(year, month, day, 23, 59, 59, 999);
        }

        public static DateTime EndOfHour()
        {
            return DateTimeHelper.EndOfHour(SystemTime.Now);
        }

        public static DateTime EndOfHour(DateTime dateTime)
        {
            return DateTimeHelper.EndOfHour(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour);
        }

        public static DateTime EndOfHour(int year, int month, int day, int hour)
        {
            return new DateTime(year, month, day, hour, 59, 59, 999);
        }

        public static DateTime EndOfMinute()
        {
            return DateTimeHelper.EndOfMinute(SystemTime.Now);
        }

        public static DateTime EndOfMinute(DateTime timeStamp)
        {
            return DateTimeHelper.EndOfMinute(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute);
        }

        public static DateTime EndOfMinute(int year, int month, int day, int hour, int minute)
        {
            return new DateTime(year, month, day, hour, minute, 59, 999);
        }

        public static DateTime EndOfMonth()
        {
            return DateTimeHelper.EndOfMonth(SystemTime.Now);
        }

        public static DateTime EndOfMonth(DateTime dateTime)
        {
            return DateTimeHelper.EndOfMonth(dateTime.Year, dateTime.Month);
        }

        public static DateTime EndOfMonth(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59, 999);
        }

        public static DateTime EndOfWeek()
        {
            return DateTimeHelper.EndOfWeek(SystemTime.Now);
        }

        public static DateTime EndOfWeek(DayOfWeek firstDayOfWeek)
        {
            return DateTimeHelper.EndOfWeek(SystemTime.Now, firstDayOfWeek);
        }

        public static DateTime EndOfWeek(DateTime dateTime)
        {
            return DateTimeHelper.EndOfWeek(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime EndOfWeek(DateTime dateTime, DayOfWeek firstDayOfWeek)
        {
            return DateTimeHelper.EndOfWeek(dateTime.Year, dateTime.Month, dateTime.Day, firstDayOfWeek);
        }

        public static DateTime EndOfWeek(int year, int month, int day)
        {
            return DateTimeHelper.EndOfWeek(year, month, day, DayOfWeek.Sunday);
        }

        public static DateTime EndOfWeek(int year, int month, int day, DayOfWeek firstDayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, day, 23, 59, 59);
            int num = (int)firstDayOfWeek - (int)dateTime.DayOfWeek;
            if (num > 0)
            {
                num -= 6;
            }
            return dateTime.AddDays((double)(num + 6));
        }

        public static DateTime EndOfYear()
        {
            return DateTimeHelper.EndOfYear(SystemTime.Now);
        }

        public static DateTime EndOfYear(DateTime dateTime)
        {
            return DateTimeHelper.EndOfYear(dateTime.Year);
        }

        public static DateTime EndOfYear(int year)
        {
            return new DateTime(year, 12, DateTime.DaysInMonth(year, 12), 23, 59, 59, 999);
        }

        public static int GetDaysBetweenDates(DateTime firstDateTime, DateTime secondDateTime)
        {
            return (secondDateTime - firstDateTime).Days;
        }

        public static double GetTotalDaysBetweenDates(DateTime oldTimeStamp, DateTime newTimeStamp)
        {
            return (newTimeStamp - oldTimeStamp).TotalDays;
        }

        public static bool IsToday(DateTime dateTime)
        {
            DateTime now = SystemTime.Now;
            if (dateTime.Day != now.Day)
            {
                return false;
            }
            if (dateTime.Month != now.Month)
            {
                return false;
            }
            if (dateTime.Year != now.Year)
            {
                return false;
            }
            return true;
        }

        public static DateTime StartOfDay()
        {
            return DateTimeHelper.StartOfDay(SystemTime.Now);
        }

        public static DateTime StartOfDay(DateTime dateTime)
        {
            return DateTimeHelper.StartOfDay(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime StartOfDay(int year, int month, int day)
        {
            return new DateTime(year, month, day, 0, 0, 0, 0);
        }

        public static DateTime StartOfHour()
        {
            return DateTimeHelper.StartOfHour(SystemTime.Now);
        }

        public static DateTime StartOfHour(DateTime dateTime)
        {
            return DateTimeHelper.StartOfHour(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour);
        }

        public static DateTime StartOfHour(int year, int month, int day, int hour)
        {
            return new DateTime(year, month, day, hour, 0, 0, 0);
        }

        public static DateTime StartOfMinute()
        {
            return DateTimeHelper.StartOfMinute(SystemTime.Now);
        }

        public static DateTime StartOfMinute(DateTime dateTime)
        {
            return DateTimeHelper.StartOfMinute(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute);
        }

        public static DateTime StartOfMinute(int year, int month, int day, int hour, int minute)
        {
            return new DateTime(year, month, day, hour, minute, 0, 0);
        }

        public static DateTime StartOfMonth()
        {
            return DateTimeHelper.StartOfMonth(SystemTime.Now);
        }

        public static DateTime StartOfMonth(DateTime dateTime)
        {
            return DateTimeHelper.StartOfMonth(dateTime.Year, dateTime.Month);
        }

        public static DateTime StartOfMonth(int year, int month)
        {
            return new DateTime(year, month, 1, 0, 0, 0, 0);
        }

        public static DateTime StartOfWeek()
        {
            return DateTimeHelper.StartOfWeek(SystemTime.Now);
        }

        public static DateTime StartOfWeek(DayOfWeek firstDayOfWeek)
        {
            return DateTimeHelper.StartOfWeek(SystemTime.Now, firstDayOfWeek);
        }

        public static DateTime StartOfWeek(DateTime dateTime)
        {
            return DateTimeHelper.StartOfWeek(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime StartOfWeek(DateTime dateTime, DayOfWeek firstDayOfWeek)
        {
            return DateTimeHelper.StartOfWeek(dateTime.Year, dateTime.Month, dateTime.Day, firstDayOfWeek);
        }

        public static DateTime StartOfWeek(int year, int month, int day)
        {
            return DateTimeHelper.StartOfWeek(year, month, day, DayOfWeek.Sunday);
        }

        public static DateTime StartOfWeek(int year, int month, int day, DayOfWeek firstDayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, day, 0, 0, 0);
            int num = (int)firstDayOfWeek - (int)dateTime.DayOfWeek;
            if (num > 0)
            {
                num -= 6;
            }
            return dateTime.AddDays((double)num);
        }

        public static DateTime StartOfYear()
        {
            return DateTimeHelper.StartOfYear(SystemTime.Now);
        }

        public static DateTime StartOfYear(DateTime dateTime)
        {
            return DateTimeHelper.StartOfYear(dateTime.Year);
        }

        public static DateTime StartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime ToDateTime(TimeSpan timeSpan, DateTime? dateTime = null)
        {
            if (!dateTime.HasValue)
            {
                dateTime = new DateTime?(DateTime.MinValue);
            }
            return dateTime.Value.Add(timeSpan);
        }

        public static TimeSpan ToTimeSpan(DateTime dateTime)
        {
            return TimeSpan.FromTicks(dateTime.Ticks);
        }
    }
}