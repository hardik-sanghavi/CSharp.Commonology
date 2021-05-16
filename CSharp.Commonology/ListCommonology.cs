using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Commonology
{
    /// <summary>
    /// Different types of common extension methods and function regarding to DateTime
    /// </summary>
    public static class ListCommonology
    {
        /// <summary>
        /// Determines whether source is not null and has any element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">System.Collections.Generic.IEnumerable`1 whose elements to apply the predicate</param>
        /// <returns>true if element not null and has any element.</returns>
        public static bool AnyItem<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// Determines whether source is not null and has any element.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">System.Collections.Generic.IEnumerable`1 whose elements to apply the predicate to</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if element not null and has any element which is pass the test in the specified predicate.</returns>
        public static bool AnyItem<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source != null && source.Any(predicate);
        }
    }
}
