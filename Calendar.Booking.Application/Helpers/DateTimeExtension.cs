using System;
using System.Globalization;

namespace Calendar.Booking.Application.Helpers
{
 
    public static class DateTimeExtension
    {

        private static readonly Random randomizer = new Random();
        public static DateTime GetEndDate(this DateTime dateTime)
        {
            return dateTime.AddMinutes(30);                
        }

        public static int GetWeekNumberByYear(this DateTime dateTime) 
        {
            var calendar = new GregorianCalendar();

            return calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);                    
        }

        public static int GetWeekNumberByMonth(this DateTime dateTime)
        {            
            var firstDay = new DateTime(dateTime.Year, dateTime.Month, 1);
            return dateTime.GetWeekNumberByYear() - firstDay.GetWeekNumberByYear() + 1;
        }

        public static DateTime GetRandomFromToday(this DateTime dateTime, int range)
        {
            return dateTime.AddDays(randomizer.Next(range));
        }
    }
}
