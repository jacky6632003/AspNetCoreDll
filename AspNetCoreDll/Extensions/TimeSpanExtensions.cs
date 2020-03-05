using AspNetCoreDll.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreDll.Extensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Average(this IEnumerable<TimeSpan> collection)
        {
            if (collection.EqualNull())
            {
                collection = new List<TimeSpan>();
            }
            if (!collection.Any<TimeSpan>())
            {
                return new TimeSpan((long)0);
            }
            return new TimeSpan((long)collection.Average<TimeSpan>((TimeSpan x) => x.Ticks));
        }

        public static int DaysRemainder(this TimeSpan timeSpan)
        {
            return (DateTime.MinValue + timeSpan).Day - 1;
        }

        public static int Months(this TimeSpan timeSpan)
        {
            return (DateTime.MinValue + timeSpan).Month - 1;
        }

        public static string ToStringFull(this TimeSpan timeSpan)
        {
            string str = "";
            string str1 = "";
            if (timeSpan.Years() > 0)
            {
                Object[] objArray = new Object[] { str, timeSpan.Years(), " year", null };
                objArray[3] = (timeSpan.Years() > 1 ? "s" : "");
                str = String.Concat(objArray);
                str1 = ", ";
            }
            if (timeSpan.Months() > 0)
            {
                Object[] objArray1 = new Object[] { str, str1, timeSpan.Months(), " month", null };
                objArray1[4] = (timeSpan.Months() > 1 ? "s" : "");
                str = String.Concat(objArray1);
                str1 = ", ";
            }
            if (timeSpan.DaysRemainder() > 0)
            {
                Object[] objArray2 = new Object[] { str, str1, timeSpan.DaysRemainder(), " day", null };
                objArray2[4] = (timeSpan.DaysRemainder() > 1 ? "s" : "");
                str = String.Concat(objArray2);
                str1 = ", ";
            }
            if (timeSpan.Hours > 0)
            {
                Object[] hours = new Object[] { str, str1, timeSpan.Hours, " hour", null };
                hours[4] = (timeSpan.Hours > 1 ? "s" : "");
                str = String.Concat(hours);
                str1 = ", ";
            }
            if (timeSpan.Minutes > 0)
            {
                Object[] minutes = new Object[] { str, str1, timeSpan.Minutes, " minute", null };
                minutes[4] = (timeSpan.Minutes > 1 ? "s" : "");
                str = String.Concat(minutes);
                str1 = ", ";
            }
            if (timeSpan.Seconds > 0)
            {
                Object[] seconds = new Object[] { str, str1, timeSpan.Seconds, " second", null };
                seconds[4] = (timeSpan.Seconds > 1 ? "s" : "");
                str = String.Concat(seconds);
            }
            return str;
        }

        public static TimeSpan ToTimeSpan(this DateTime dateTime)
        {
            return DateTimeHelper.ToTimeSpan(dateTime);
        }

        public static int Years(this TimeSpan timeSpan)
        {
            return (DateTime.MinValue + timeSpan).Year - 1;
        }
    }
}