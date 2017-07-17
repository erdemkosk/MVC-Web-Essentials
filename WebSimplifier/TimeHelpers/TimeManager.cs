using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSimplifier.TimeHelpers
{
    public class TimeManager
    {
        private static string systemTimeZoneById = "Turkey Standard Time";

        public static string SystemTimeZoneById
        {
            get
            {
                return systemTimeZoneById;
            }
            set
            {
                systemTimeZoneById = value;
            }
        }
        public static DateTime GetLocalTime() // default Turkish For Me
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(systemTimeZoneById);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        }
        public static DateTime GetLocalTime(string timeFormat)
        {
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeFormat);
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local
        }
    }
}
