using System;
using System.Globalization;

namespace Calendar.Booking.Application.Helpers
{
    public static class DateStringHelper
    {
        public static DateTime ToDatetime(string daymonth, string hoursmins)
        {
            return DateTime.ParseExact($"{daymonth}/{DateTime.Now.Year} {hoursmins}", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
