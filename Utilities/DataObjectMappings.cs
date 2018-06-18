using App_CommonLibraries.Objects.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Utilities
{
    /// <summary>
    /// Class to map column names to object properties attributes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DataNamesAttribute : Attribute
    {
        protected List<string> _valueNames { get; set; }

        public List<string> ValueNames
        {
            get
            {
                return _valueNames;
            }
            set
            {
                _valueNames = value;
            }
        }

        public DataNamesAttribute()
        {
            _valueNames = new List<string>();
        }

        public DataNamesAttribute(params string[] valueNames)
        {
            _valueNames = valueNames.ToList();
        }
    }

    /// <summary>
    /// Class to map from DataTable or DataRow objects to any kind of object
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DataNamesMapper<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Map single object from data row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public TEntity Map(DataRow row)
        {
            //Step 1 - Get the Column Names
            var columnNames = row.Table.Columns
                                       .Cast<DataColumn>()
                                       .Select(x => x.ColumnName)
                                       .ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                              .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                              .ToList();

            //Step 3 - Map the data
            TEntity entity = new TEntity();
            foreach (var prop in properties)
            {
                PropertyMapHelper(typeof(TEntity), row, prop, entity);
            }

            return entity;
        }

        /// <summary>
        /// Map collection of objects from data table
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Map(DataTable table)
        {
            //Step 1 - Get the Column Names
            var columnNames = table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();

            //Step 2 - Get the Property Data Names
            var properties = (typeof(TEntity)).GetProperties()
                                                .Where(x => x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any())
                                                .ToList();

            //Step 3 - Map the data
            List<TEntity> entities = new List<TEntity>();
            foreach (DataRow row in table.Rows)
            {
                TEntity entity = new TEntity();
                foreach (var prop in properties)
                {
                    PropertyMapHelper(typeof(TEntity), row, prop, entity);
                }
                entities.Add(entity);
            }

            return entities;
        }

        /// <summary>
        /// maps values to different primitive types (int,  string, DateTime, etc.)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <param name="prop"></param>
        /// <param name="entity"></param>
        public static void PropertyMapHelper(Type type, DataRow row, PropertyInfo prop, object entity)
        {
            List<string> columnNames = GetDataNames(type, prop.Name);

            foreach (var columnName in columnNames)
            {
                if (!String.IsNullOrWhiteSpace(columnName) && row.Table.Columns.Contains(columnName))
                {
                    var propertyValue = row[columnName];
                    if (propertyValue != DBNull.Value)
                    {
                        ParsePrimitive(prop, entity, row[columnName]);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get the list of column names from the DataNamesAttribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static List<string> GetDataNames(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName).GetCustomAttributes(false).Where(x => x.GetType().Name == "DataNamesAttribute").FirstOrDefault();
            if (property != null)
            {
                return ((DataNamesAttribute)property).ValueNames;
            }
            return new List<string>();
        }

        /// <summary>
        /// assign a value to a passed-in property reference (represented by the PropertyInfo class)
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
        {
            if (prop.PropertyType == typeof(string))
            {
                prop.SetValue(entity, value.ToString().Trim(), null);
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
            {
                if (value == null)
                {
                    prop.SetValue(entity, null, null);
                }
                else
                {
                    prop.SetValue(entity, int.Parse(value.ToString()), null);
                }
            }
        }
    }


    #region Sample Implementation
    class Program
    {
        static void Main(string[] args)
        {
            var employeeDataSet = Employee.GetEmployees(); // DataSetGenerator.Priests();
            DataNamesMapper<Employee> mapper = new DataNamesMapper<Employee>();
            List<Employee> persons = mapper.Map(employeeDataSet.Tables[0]).ToList();

            //var ranchersDataSet = DataSetGenerator.Ranchers();
            //persons.AddRange(mapper.Map(ranchersDataSet.Tables[0]));

            foreach (var person in persons)
            {
                //TODO assignment
            }

            Console.ReadLine();
        }
    }
    #endregion

}
