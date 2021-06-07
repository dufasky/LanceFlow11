using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanceFlow.Models
{
    public class DateTimeFormatter
    {
        public static DateTime DateFormatter(DateTime time)
        {
            int year = time.Year;
            int mounth = time.Month;
            int day = time.Day;
            int hour = time.Hour;
            int min = time.Minute;
            int sec = time.Second;
            int msec = time.Millisecond;
                return new DateTime(year, day, mounth, hour, min, sec, msec);
        }
    }
}
