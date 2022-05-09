using System;
using System.Collections.Generic;
using System.Data;

namespace CSharp.Commonology
{
    /// <summary>
    /// Different types of common extension methods and functions releted to datatable
    /// </summary>
    public static class DatatableCommonology
    {
        /// <summary>
        /// Convert the datatable to list
        /// </summary>
        /// <typeparam name="T">Convert the datatable into list of this object</typeparam>
        /// <param name="dt">Datatable that needs to convert</param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();

            if (dt == null) return data;
            
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            var properties = temp.GetProperties();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    if (property.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] != DBNull.Value)
                            property.SetValue(obj, dr[column.ColumnName], null);
                        break;
                    }
                }
            }
            return obj;
        }
    }
}
