using System;
using System.Collections.Generic;
using System.Linq;
namespace Extensions.DateTime
{
    public static class DateTimeExtensions
    {
        public static System.DateTime AddQuarter(this System.DateTime dateTime)
        {
            return dateTime.AddMonths(3);
        }

        public static bool IsBusinessDay(this System.DateTime dateTime, IEnumerable<System.DateTime> holidays = null)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday
                || holidays == null
                || holidays.Contains(dateTime))
                return false;
            return true;
        }

        public static TimeSpan GetRemainingTimeOfYear(this System.DateTime dateTime)
        {
            var endOfYear = new System.DateTime(dateTime.Year, 12, 31);
            return endOfYear - dateTime;
        }

        public static double GetRemainingDaysOfYear(this System.DateTime dateTime)
        {
            var endOfYear = new System.DateTime(dateTime.Year, 12, 31);
            return (endOfYear - dateTime).TotalDays;
        }

        public static System.DateTime AddBusinessDays(this System.DateTime current, int days, IEnumerable<System.DateTime> holidays = null)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (int i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                }
                while (current.DayOfWeek == DayOfWeek.Saturday
                || current.DayOfWeek == DayOfWeek.Sunday
                || (holidays != null && holidays.Contains(current.Date)));
            }
            return current;
        }

        public static System.DateTime SubtractBusinessDays(this System.DateTime current, int days, IEnumerable<System.DateTime> holidays)
        {
            return AddBusinessDays(current, -days, holidays);
        }

        public static int GetBusinessDays(this System.DateTime startDate, System.DateTime endDate, IEnumerable<System.DateTime> holidays)
        {
            if (startDate > endDate)
                return -1;
            int cnt = 0;
            for (var current = startDate; current < endDate; current = current.AddDays(1))
            {
                if (current.DayOfWeek == DayOfWeek.Saturday
                    || current.DayOfWeek == DayOfWeek.Sunday
                    || holidays != null
                    || holidays.Contains(current.Date)) { }
                else
                    cnt++;
            }
            return cnt;
        }
    }
}