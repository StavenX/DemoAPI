using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetFirstMondayOfYear()
        {
            var currentYear = DateTime.Now.Year;
            DateTime firstWeek = new DateTime(currentYear, 1, 1);

            while (firstWeek.DayOfWeek != DayOfWeek.Monday)
            {
                firstWeek = firstWeek.AddDays(1);
            }

            return firstWeek; 
        }

        public static DateTime GetFirstMondayOfWeek(int weekNumber)
        {
            var firstMondayInYear = GetFirstMondayOfYear();
            var firstMondayOfWeek = firstMondayInYear.AddDays(7 * (weekNumber - 1));

            return firstMondayOfWeek;
        }

        public static bool IsWithinWeekNumber(DateTime startTime, DateTime endTime, int weekNumber)
        {
            var beginningDay = GetFirstMondayOfWeek(weekNumber);
            var endDay = beginningDay.AddDays(6);

            var isAfterMonday = startTime >= beginningDay;
            var isBeforeSunday = endTime <= endDay; 

            if (isAfterMonday && isBeforeSunday)
            {
                return true; 
            }

            return false; 
        }
    }
}
