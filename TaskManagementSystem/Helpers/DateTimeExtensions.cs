using System;

namespace TaskManagementSystem.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            int diff = date.DayOfWeek - dayOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return date.AddDays(-diff).Date;
        }
    }
}
