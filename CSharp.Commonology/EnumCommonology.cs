using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CSharp.Commonology
{
    public static class EnumCommonology
    {
        public enum DateTimeForamte
        {
            [Date("dd/MM/yyyy")]
            [DateTime("dd/MM/yyyy hh:mm tt")]
            ddMMyyyy,

            [Date("MM/dd/yyyy")]
            [DateTime("MM/dd/yyyy hh:mm tt")]
            MMddyyyy,

            [Date("dd MMMM, yyyy")]
            [DateTime("dd MMMM, yyyy hh:mm tt")]
            ddMMyyyyIncludehMonth,

            [Date("MMMM dd, yyyy")]
            [DateTime("MMMM dd, yyyy hh:mm tt")]
            MMddyyyyIncludehMonth,
        }

        /// <summary>
        /// Generic method to get any type of attribute of Enums
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes.FirstOrDefault();//attributes.Length > 0 ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Get the value of Display attribute of Enum e.g. [Display("First Name")] 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        public static string ToDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static dynamic ToSelectList<TEnum>(this TEnum enumObj)
           where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };
            return values;
        }
    }


    internal class DateAttribute : Attribute
    {
        public string Value;
        public DateAttribute(string value)
        {
            this.Value = value;
        }
    }

    internal class DateTimeAttribute : Attribute
    {
        public string Value;
        public DateTimeAttribute(string value)
        {
            this.Value = value;
        }
    }
}
