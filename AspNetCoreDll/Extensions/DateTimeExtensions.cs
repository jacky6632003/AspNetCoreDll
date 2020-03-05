using AspNetCoreDll.Enums;
using AspNetCoreDll.Helpers;
using AspNetCoreDll.Misc;
using System;
using System.Globalization;

namespace AspNetCoreDll.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWeeks(this DateTime dateTime, int numberOfWeeks)
        {
            return dateTime.AddDays((double)(numberOfWeeks * 7));
        }

        public static int Age(this DateTime dateTime, DateTime calculateFrom)
        {
            if (calculateFrom == new DateTime())
            {
                calculateFrom = SystemTime.Now;
            }
            return (calculateFrom - dateTime).Years();
        }

        public static DateTime BeginningOf(this DateTime dateTime, TimeFrame timeFrame, CultureInfo culture = null)
        {
            if (culture.EqualNull())
            {
                culture = CultureInfo.CurrentCulture;
            }
            if (timeFrame.Equals(TimeFrame.Day))
            {
                return dateTime.Date;
            }
            if (timeFrame.Equals(TimeFrame.Week))
            {
                DateTime dateTime1 = dateTime.AddDays((double)((int)culture.DateTimeFormat.FirstDayOfWeek - (int)dateTime.DayOfWeek));
                return dateTime1.Date;
            }
            if (timeFrame.Equals(TimeFrame.Month))
            {
                return new DateTime(dateTime.Year, dateTime.Month, 1);
            }
            if (!timeFrame.Equals(TimeFrame.Quarter))
            {
                return new DateTime(dateTime.Year, 1, 1);
            }
            return dateTime.BeginningOf(TimeFrame.Quarter, dateTime.BeginningOf(TimeFrame.Year, culture), culture);
        }

        public static DateTime BeginningOf(this DateTime dateTime, TimeFrame timeFrame, DateTime startOfQuarter1, CultureInfo culture = null)
        {
            DateTime dateTime1;
            if (timeFrame != TimeFrame.Quarter)
            {
                return dateTime.BeginningOf(timeFrame, culture);
            }
            if (culture.EqualNull())
            {
                culture = CultureInfo.CurrentCulture;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1, startOfQuarter1.AddMonths(3).AddDays(-1).EndOf(TimeFrame.Day, CultureInfo.CurrentCulture), null))
            {
                return startOfQuarter1.Date;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1.AddMonths(3), startOfQuarter1.AddMonths(6).AddDays(-1).EndOf(TimeFrame.Day, CultureInfo.CurrentCulture), null))
            {
                dateTime1 = startOfQuarter1.AddMonths(3);
                return dateTime1.Date;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1.AddMonths(6), startOfQuarter1.AddMonths(9).AddDays(-1).EndOf(TimeFrame.Day, CultureInfo.CurrentCulture), null))
            {
                dateTime1 = startOfQuarter1.AddMonths(6);
                return dateTime1.Date;
            }
            dateTime1 = startOfQuarter1.AddMonths(9);
            return dateTime1.Date;
        }

        public static DateTime EndOf(this DateTime dateTime, TimeFrame timeFrame, CultureInfo culture = null)
        {
            DateTime dateTime1;
            if (culture.EqualNull())
            {
                culture = CultureInfo.CurrentCulture;
            }
            if (timeFrame.Equals(TimeFrame.Day))
            {
                return DateTimeHelper.EndOfDay(dateTime);
            }
            if (timeFrame.Equals(TimeFrame.Week))
            {
                dateTime1 = dateTime.BeginningOf(TimeFrame.Week, culture);
                return dateTime1.AddDays(6);
            }
            if (timeFrame.Equals(TimeFrame.Month))
            {
                dateTime1 = dateTime.AddMonths(1).BeginningOf(TimeFrame.Month, culture);
                dateTime1 = dateTime1.AddDays(-1);
                return dateTime1.Date;
            }
            if (!timeFrame.Equals(TimeFrame.Quarter))
            {
                return new DateTime(dateTime.Year, 12, 31);
            }
            return dateTime.EndOf(TimeFrame.Quarter, dateTime.BeginningOf(TimeFrame.Year, culture), culture);
        }

        public static DateTime EndOf(this DateTime dateTime, TimeFrame timeFrame, DateTime startOfQuarter1, CultureInfo culture = null)
        {
            DateTime dateTime1;
            if (timeFrame != TimeFrame.Quarter)
            {
                return dateTime.EndOf(timeFrame, culture);
            }
            if (culture.EqualNull())
            {
                culture = CultureInfo.CurrentCulture;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1, startOfQuarter1.AddMonths(3).AddDays(-1).EndOf(TimeFrame.Day, culture), null))
            {
                dateTime1 = startOfQuarter1.AddMonths(3);
                dateTime1 = dateTime1.AddDays(-1);
                return dateTime1.Date;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1.AddMonths(3), startOfQuarter1.AddMonths(6).AddDays(-1).EndOf(TimeFrame.Day, culture), null))
            {
                dateTime1 = startOfQuarter1.AddMonths(6);
                dateTime1 = dateTime1.AddDays(-1);
                return dateTime1.Date;
            }
            if (dateTime.Between<DateTime>(startOfQuarter1.AddMonths(6), startOfQuarter1.AddMonths(9).AddDays(-1).EndOf(TimeFrame.Day, culture), null))
            {
                dateTime1 = startOfQuarter1.AddMonths(9);
                dateTime1 = dateTime1.AddDays(-1);
                return dateTime1.Date;
            }
            dateTime1 = startOfQuarter1.AddYears(1);
            dateTime1 = dateTime1.AddDays(-1);
            return dateTime1.Date;
        }

        public static DateTime FromDigit14(this string digits)
        {
            DateTime dateTime;
            if (digits.IsNullOrWhiteSpace() || digits.Length != 14 || digits.IsNumber().Equals(false))
            {
                return DateTime.MinValue;
            }
            try
            {
                dateTime = new DateTime(Convert.ToInt32(digits.Substring(0, 4)), Convert.ToInt32(digits.Substring(4, 2)), Convert.ToInt32(digits.Substring(6, 2)), Convert.ToInt32(digits.Substring(8, 2)), Convert.ToInt32(digits.Substring(10, 2)), Convert.ToInt32(digits.Substring(12, 2)));
            }
            catch
            {
                dateTime = DateTime.MinValue;
            }
            return dateTime;
        }

        public static DateTime FromDigit17(this string digits)
        {
            DateTime dateTime;
            if (digits.IsNullOrWhiteSpace() || digits.Length != 17 || digits.IsNumber().Equals(false))
            {
                return DateTime.MinValue;
            }
            try
            {
                dateTime = new DateTime(Convert.ToInt32(digits.Substring(0, 4)), Convert.ToInt32(digits.Substring(4, 2)), Convert.ToInt32(digits.Substring(6, 2)), Convert.ToInt32(digits.Substring(8, 2)), Convert.ToInt32(digits.Substring(10, 2)), Convert.ToInt32(digits.Substring(12, 2)), Convert.ToInt32(digits.Substring(14, 3)));
            }
            catch
            {
                dateTime = DateTime.MinValue;
            }
            return dateTime;
        }

        public static DateTime FromDigit8(this string digits)
        {
            DateTime dateTime;
            if (digits.IsNullOrWhiteSpace() || digits.Length != 8 || !digits.IsNumber())
            {
                return DateTime.MinValue;
            }
            try
            {
                dateTime = new DateTime(Convert.ToInt32(digits.Substring(0, 4)), Convert.ToInt32(digits.Substring(4, 2)), Convert.ToInt32(digits.Substring(6, 2)));
            }
            catch
            {
                dateTime = DateTime.MinValue;
            }
            return dateTime;
        }

        public static DateTime ToDateTime(this long timeSpan, DateTimeKind dateTimeKind)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, dateTimeKind);
            return dateTime.AddSeconds((double)timeSpan);
        }

        public static DateTime ToDateTime(this long timeSpan, int cutLength = 0, DateTimeKind dateTimeKind = 0)
        {
            return Convert.ToInt64(timeSpan.ToString().Substring(0, timeSpan.ToString().Length - cutLength)).ToDateTime(dateTimeKind);
        }

        public static string ToFullTaiwanDate(this DateTime datetime)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            return "民國 {0} 年 {1} 月 {2} 日".ToFormat(new Object[] { taiwanCalendar.GetYear(datetime), datetime.ToString("MM"), datetime.Day });
        }

        public static string ToFullTaiwanDate(this DateTime datetime, bool ampm = false)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            Object[] year = new Object[] { taiwanCalendar.GetYear(datetime), datetime.ToString("MM"), datetime.Day, null, null, null };
            year[3] = (ampm ? String.Concat(datetime.ToString("tt", new CultureInfo("en-US")).ToUpper(), " ") : "");
            year[4] = (ampm ? datetime.ToString("hh") : datetime.ToString("HH"));
            year[5] = datetime.ToString("mm");
            return "民國 {0} 年 {1} 月 {2} 日 {3}{4}:{5}".ToFormat(year);
        }

        public static string ToSimpleTaiwanDate(this DateTime datetime)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            return "{0}/{1}/{2}".ToFormat(new Object[] { taiwanCalendar.GetYear(datetime), datetime.ToString("MM"), datetime.Day });
        }

        public static string ToSimpleTaiwanDate(this DateTime datetime, bool ampm)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            Object[] year = new Object[] { taiwanCalendar.GetYear(datetime), datetime.ToString("MM"), datetime.Day, null, null, null };
            year[3] = (ampm ? String.Concat(datetime.ToString("tt", new CultureInfo("en-US")).ToUpper(), " ") : "");
            year[4] = (ampm ? datetime.ToString("hh") : datetime.ToString("HH"));
            year[5] = datetime.ToString("mm");
            return "{0}/{1}/{2} {3}{4}:{5}".ToFormat(year);
        }

        public static string ToString12(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm");
        }

        public static string ToString12s(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmm");
        }

        public static string ToString14(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToString14s(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }

        public static string ToString17(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public static string ToString17s(this DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssfff");
        }

        public static string ToString4(this DateTime date)
        {
            return date.ToString("yyyy");
        }

        public static string ToString8(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string ToString8s(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        public static string ToTaiwanDate(this DateTime datetime)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            return "{0}年{1}月{2}日".ToFormat(new Object[] { taiwanCalendar.GetYear(datetime), datetime.Month, datetime.Day });
        }

        public static string ToTaiwanDate(this DateTime datetime, bool ampm = false)
        {
            TaiwanCalendar taiwanCalendar = new TaiwanCalendar();
            Object[] year = new Object[] { taiwanCalendar.GetYear(datetime), datetime.ToString("MM"), datetime.Day, null, null, null };
            year[3] = (ampm ? String.Concat(datetime.ToString("tt", new CultureInfo("en-US")).ToUpper(), " ") : "");
            year[4] = (ampm ? datetime.ToString("hh") : datetime.ToString("HH"));
            year[5] = datetime.ToString("mm");
            return "{0}年{1}月{2}日 {3}{4}:{5}".ToFormat(year);
        }

        public static long ToTimestamp(this DateTime date, DateTimeKind dateTimeKind)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, dateTimeKind);
            return (long)date.Subtract(dateTime).TotalSeconds;
        }

        public static string ToUniversalTimeFormat(this DateTime dateTime, string format = "")
        {
            if (format.IsNullOrWhiteSpace())
            {
                format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK";
            }
            return dateTime.ToUniversalTime().ToString(format);
        }
    }
}