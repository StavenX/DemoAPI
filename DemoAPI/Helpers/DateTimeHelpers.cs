using System;

namespace DemoAPI.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime GetFirstMondayOfYear()
        {
            var currentYear = DateTime.Now.Year;
            DateTime firstMonday = new DateTime(currentYear, 1, 1);

            while (firstMonday.DayOfWeek != DayOfWeek.Monday)
            {
                firstMonday = firstMonday.AddDays(1);
            }

            return firstMonday;
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
            var endDay = beginningDay.AddDays(7);

            var isAfterMonday = startTime >= beginningDay;
            var isWithinSunday = endTime < endDay;

            if (isAfterMonday && isWithinSunday)
            {
                return true;
            }

            return false;
        }
    }
}
