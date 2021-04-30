using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Commonology
{
    /// <summary>
    /// Different types of common extension methods and function regarding to DateTime
    /// </summary>
    public static class DateTimeCommonology
    {

        /// <summary>
        /// Converts the time in a (UTC) to specified time zone.
        /// </summary>
        /// <param name="dateTime">UTC DateTime which need to convert into specific timezone.</param>
        /// <param name="timeZoneId">TimeZone Id in which need to convert. Use timezone StandardName.</param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTime dateTime, string timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
                timeZoneId = TimeZoneInfo.Local.Id;

            TimeZoneInfo destinationTimeZone;
            try
            {
                destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (Exception)
            {
                destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            }          
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
        }

        /// <summary>
        ///  Converts the time in a specified time zone to (UTC).
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeZoneId">TimeZone Id from which need to convert. Use timezone StandardName.</param>
        /// <returns></returns>
        public static DateTime ToUTCDateTime(this DateTime dateTime, string timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
                timeZoneId = TimeZoneInfo.Local.Id;

            TimeZoneInfo destinationTimeZone;
            try
            {
                destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (Exception)
            {
                destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            }           
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, destinationTimeZone);
        }

        /// <summary>
        /// Convert the one time zone to other time zone.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="sourceTimeZoneId">TimeZoneId which need to convert. Use timezone StandardName.</param>
        /// <param name="destinationTimeZoneId">TimeZoneId in which need to convert.  Use timezone StandardName.</param>
        /// <returns></returns>
        public static DateTime ConvertToTimeZoneTime(this DateTime dateTime, string sourceTimeZoneId, string destinationTimeZoneId)
        {
            if (string.IsNullOrWhiteSpace(sourceTimeZoneId))
                sourceTimeZoneId = TimeZoneInfo.Local.Id;

            if (string.IsNullOrWhiteSpace(destinationTimeZoneId))
                destinationTimeZoneId = TimeZoneInfo.Utc.Id;

            TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
            TimeZoneInfo sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);

            return TimeZoneInfo.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date and time to convert.</param>
        /// <param name="timeZoneId">The time zone to convert dateTime to.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy hh:mm tt</param>
        /// <returns></returns>
        public static string ToLocalDateTimeString(this DateTime? dateTime, string timeZoneId, string formate = "MM/dd/yyyy hh:mm tt")
        {
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTimeString(timeZoneId, formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date and time to convert.</param>
        /// <param name="timeZoneId">The time zone to convert dateTime to.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy hh:mm tt</param>
        /// <returns></returns>
        public static string ToLocalDateTimeString(this DateTime dateTime, string timeZoneId, string formate = "MM/dd/yyyy hh:mm tt")
        {
            return dateTime.ToLocalDateTime(timeZoneId).ToString(formate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date and time to convert.</param>
        /// <param name="timeZoneId">The time zone to convert dateTime to.</param>
        /// <param name="formate">The formate of datetime to convert.</param>
        /// <returns></returns>
        public static string ToLocalDateTimeString(this DateTime? dateTime, string timeZoneId, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTimeString(timeZoneId, formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date and time to convert.</param>
        /// <param name="timeZoneId">The time zone to convert dateTime to.</param>
        /// <param name="formate">The formate of datetime to convert.</param>
        /// <returns></returns>
        public static string ToLocalDateTimeString(this DateTime dateTime, string timeZoneId, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.ToLocalDateTime(timeZoneId).ToString(formate.GetAttribute<DateTimeAttribute>()?.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <param name="timeZoneId">The time zone to convert date to.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy</param>
        /// <returns></returns>
        public static string ToLocalDateString(this DateTime? dateTime, string timeZoneId, string formate = "MM/dd/yyyy")
        {
            return dateTime.HasValue ? dateTime.Value.ToLocalDateString(timeZoneId, formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <param name="timeZoneId">The time zone to convert date to.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy</param>
        /// <returns></returns>
        public static string ToLocalDateString(this DateTime dateTime, string timeZoneId, string formate = "MM/dd/yyyy")
        {
            return dateTime.ToLocalDateTime(timeZoneId).ToString(formate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <param name="timeZoneId">The time zone to convert date to.</param>
        /// <param name="formate">The formate of date to convert.</param>
        /// <returns></returns>
        public static string ToLocalDateString(this DateTime? dateTime, string timeZoneId, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.HasValue ? dateTime.Value.ToLocalDateString(timeZoneId, formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <param name="timeZoneId">The time zone to convert date to.</param>
        /// <param name="formate">The formate of date to convert.</param>
        /// <returns></returns>
        public static string ToLocalDateString(this DateTime dateTime, string timeZoneId, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.ToLocalDateTime(timeZoneId).ToString(formate.GetAttribute<DateAttribute>()?.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date and time to convert.</param>
        /// <param name="formate">The formate of datetime to convert.</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime? dateTime, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.HasValue ? dateTime.Value.ToDateTimeString(formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date and time to convert.</param>
        /// <param name="formate">The formate of datetime to convert.</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime dateTime, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.ToString(formate.GetAttribute<DateTimeAttribute>()?.Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dateTime, string formate = "MM/dd/yyyy")
        {
            return dateTime.HasValue ? dateTime.Value.ToDateString(formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="formate">The formate of string. If pass null it use MM/dd/yyyy</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime, string formate = "MM/dd/yyyy")
        {
            return dateTime.ToString(formate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="formate">The formate of date to convert.</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime? dateTime, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.HasValue ? dateTime.Value.ToDateString(formate) : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="formate">The formate of date to convert.</param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime, EnumCommonology.DateTimeForamte formate)
        {
            return dateTime.ToString(formate.GetAttribute<DateAttribute>()?.Value);
        }

        /// <summary>
        /// Convert the datetime to Unix TimeStamp
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>Returns the number of seconds that have elapsed since 1970-01-01T00:00:00Z.</returns>
        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = dateTime - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        /// <summary>
        /// Convert the Unix TimeStamp seconds to UTC datetime
        /// </summary>
        /// <param name="unixMS"></param>
        /// <returns></returns>
        public static DateTime ConvrtUnixToDate(this double unixMS)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixMS);
            return dtDateTime;
        }


        /// <summary>
        /// Get the string for the Ago time like 5 minutes ago, 1 day ago etc.
        /// </summary>
        /// <param name="dateTime">UTC Datetime to calculate the ago time based on.</param>
        /// <returns></returns>
        public static string ToDisplayRelativeAgoTime(this DateTime dateTime)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dateTime.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "1 month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "1 year ago" : years + " years ago";
            }
        }

        /// <summary>
        /// Get the true of false value if date is between the start date and end date
        /// </summary>
        /// <param name="sourceDateTime">Datetime which need to check</param>
        /// <param name="startDateTime">A start date time</param>
        /// <param name="endDateTime">A end date time</param>
        /// <param name="includeBothDate">if true than start and end date also included for check</param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime sourceDateTime, DateTime startDateTime, DateTime endDateTime, bool includeBothDate = false)
        {
            return includeBothDate ? sourceDateTime >= startDateTime && sourceDateTime <= endDateTime : sourceDateTime > startDateTime && sourceDateTime < endDateTime;
        }        
    }
}
