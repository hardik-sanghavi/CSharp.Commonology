﻿using System;
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

        /// <summary>
        /// Retunrn the initilize character by length exmaple: source is xyz and length =1 than return x
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <param name="isUperCase"></param>
        /// <returns></returns>
        public static string ToInitilizeCharacters(this string source, int length, bool isUperCase = true)
        {
            source = (source ?? String.Empty);
            if (source.Length >= length)
            {
                if (isUperCase)
                    source = source.Substring(0, length).ToUpper();
                else
                    source = source.Substring(0, length);
            }
            return source;
        }
    }
}
