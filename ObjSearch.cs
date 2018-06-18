using App_CommonLibraries.DALHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries
{
    public class SearchClass
    {
        public static DataTable GetSearchData(string query)
        {
            return CommonDAL.GetData(query);
        }
        public static DataTable GetSearchData(string tableName, int rowCount)
        {
            return CommonDAL.FetchSearchData(tableName, rowCount);
        }
        public static DataTable GetOperationSearchData(string customerCode)
        {
            return CommonDAL.GetData(CommonSQLStrings.GetOperationQuery(customerCode));
        }
        public static DataTable GetCustomerSearchData()
        {
            return CommonDAL.GetData(CommonSQLStrings.GetCustomerQuery(""));
        }

        public static string GetSearchQuery(string tableName)
        {
            string retValue = null;
            if (tableName.ToUpper().Contains("CUSTOMER"))
            {
                return App_CommonLibraries.DALHelper.CommonSQLStrings.GetCustomerQuery("");
            }
            else if (tableName.ToUpper().Contains("OPERATION"))
            {
                return App_CommonLibraries.DALHelper.CommonSQLStrings.GetCustomerQuery("");
            }
            else if (tableName.ToUpper().Contains("PORT"))
            {
                return App_CommonLibraries.DALHelper.CommonSQLStrings.GetCustomerQuery("");
            }
            else if (tableName.ToUpper().Contains("EMPLOYEE"))
            {
                return App_CommonLibraries.DALHelper.CommonSQLStrings.GetCustomerQuery("");
            }
            return retValue;
        }

    }
}
