using System.Text.Json;

namespace CSharp.Commonology
{
    /// <summary>
    /// Different types of common extension methods and functions releted to object
    /// </summary>
    public static class ObjectCommonology
    {
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">serialize the string of this object</param>
        /// <returns>Return json serialize string. If object is null return the null string</returns>
        public static string ToSerializeString<T>(this T obj)
        {
            if (obj == null) return null;
            return JsonSerializer.Serialize(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ToDeserializeObject<T>(this string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString)) return default(T);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
