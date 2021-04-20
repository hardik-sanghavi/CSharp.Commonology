using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Commonology
{
    public static class DateTimeCommonologycs
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
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTime(timeZoneId).ToString(formate) : string.Empty;
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
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTime(timeZoneId).ToString(formate.GetAttribute<DateTimeAttribute>()?.Value) : string.Empty;
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
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTime(timeZoneId).ToString(formate) : string.Empty;
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
            return dateTime.HasValue ? dateTime.Value.ToLocalDateTime(timeZoneId).ToString(formate.GetAttribute<DateAttribute>()?.Value) : string.Empty;
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
        /// Convert the Unix TimeStamp seconds to datetime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ConvrtUnixToDate(this double unixMS)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixMS);
            return dtDateTime;
        }

    }
}
