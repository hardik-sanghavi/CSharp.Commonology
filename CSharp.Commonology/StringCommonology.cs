using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp.Commonology
{
    /// <summary>
    /// Different types of common extension methods and function regarding to string
    /// </summary>
    public static class StringCommonology
    {
        /// <summary>
        /// Return the lower string with trim and Null handling
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToLowerWithTrim(this string source)
        {
            return (source ?? string.Empty).ToLower().Trim();
        }

        /// <summary>
        /// Return the Upper string with trim and Null handling
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToUpperWithTrim(this string source)
        {
            return (source ?? string.Empty).ToUpper().Trim();
        }

        /// <summary>
        /// Return the string without the HTML
        /// </summary>
        /// <param name="html">HTML string which want to strip the HTML</param>
        /// <returns></returns>
        public static string StripHtml(this string html)
        {
            return Regex.Replace(html, "<.*?>", String.Empty);
        }

        /// <summary>
        /// Remove the special characters from the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace((str ?? string.Empty), "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
    }
}
