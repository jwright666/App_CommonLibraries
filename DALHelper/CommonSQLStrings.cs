using App_CommonLibraries.Objects.Common;
using App_CommonLibraries.Utilities;
using App_CommonLibraries.Utilities.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.DALHelper
{
    public class CommonSQLStrings
    {
        public string GET_DATA = @"SELECT * FROM {0} WHERE 1=1 ";

        #region Employee queries
        public static string GetEmployeesQuery()
        {
            return @"SELECT * FROM [TPT_Trucking_Employee_Tbl]";
        }
        public static string GetEmployeeQuery(string code)
        {
            string query = @"SELECT * FROM [TPT_Trucking_Employee_Tbl] WHERE Code = '{0}'";
            query = string.Format(query, CommonUtilities.FormatString(code));
            return query;
        }
        public static string DeleteEmployeeQuery(string code)
        {
            string query = @"DELETE FROM [TPT_Trucking_Employee_Tbl] WHERE Code = '{0}'";
            query = string.Format(query, CommonUtilities.FormatString(code));
            return query;
        }
        public static string UpdateEmployeeQuery(Employee employee)
        {
            string query = @"UPDATE [dbo].[TPT_Trucking_Employee_Tbl]
                                           SET [FirstName] = '{1}'
                                              ,[MiddleName] = '{2}'
                                              ,[LastName] = '{3}'
                                              ,[NRIC] = '{4}'
                                              ,[Nationality] = '{5}'
                                              ,[Driving_Licence_No] = '{6}'
                                              ,[Driving_Class] = '{7}'
                                              ,[Licence_Expiry_Date] ='{8}'
                                              ,[Is_Available] = '{9}'
                                              ,[Employ_Status] ='{10}'
                                              ,[Phone_No] = '{11}'
                                              ,[Mobile_No] ='{12}'
                                              ,[Email] = '{13}'
                                              ,[Address] = '{14}'
                                              ,[Address2] ='{15}'
                                              ,[Address3] ='{16}'
                                              ,[Address4] ='{17}'
                                              ,[City] ='{18}'
                                              ,[SSS_ID] = '{19}'
                                              ,[TAX_ID] = '{20}'
                                              ,[Philhealth_ID] = '{21}'
                                              ,[Role] = '{22}'
                                         WHERE Code = '{0}'";
            query = string.Format(query, CommonUtilities.FormatString(employee.Code)
                                            , CommonUtilities.FormatString(employee.FirstName)
                                            , CommonUtilities.FormatString(employee.MiddleName)
                                            , CommonUtilities.FormatString(employee.LastName)
                                            , CommonUtilities.FormatString(employee.Nirc)
                                            , CommonUtilities.FormatString(employee.Nationality)
                                            , CommonUtilities.FormatString(employee.DrivingLicence)
                                            , CommonUtilities.FormatString(employee.DrivingClass)
                                            , CommonUtilities.ConvertDateForSQLPurpose(employee.LicenceExpiryDate)
                                            , employee.IsAvailable ? "T" : "F"
                                            , employee.EmployeeStatus == Employee_Status.Available ? "A" : "R"
                                            , CommonUtilities.FormatString(employee.Phone_no)
                                            , CommonUtilities.FormatString(employee.Mobile_no)
                                            , CommonUtilities.FormatString(employee.Email_add)
                                            , CommonUtilities.FormatString(employee.Address1)
                                            , CommonUtilities.FormatString(employee.Address2)
                                            , CommonUtilities.FormatString(employee.Address3)
                                            , CommonUtilities.FormatString(employee.Address4)
                                            , CommonUtilities.FormatString(employee.City)
                                            , CommonUtilities.FormatString(employee.SSS_ID)
                                            , CommonUtilities.FormatString(employee.Tax_ID)
                                            , CommonUtilities.FormatString(employee.Philhealth_ID)
                                            , employee.Role.GetHashCode());

            return query;
        }
        public static string InsertEmployeeQuery(Employee employee)
        {
            string query = @"INSERT INTO [dbo].[TPT_Trucking_Employee_Tbl]
                                                               ([Code]
                                                               ,[FirstName]
                                                               ,[MiddleName]
                                                               ,[LastName]
                                                               ,[NRIC]
                                                               ,[Nationality]
                                                               ,[Driving_Licence_No]
                                                               ,[Driving_Class]
                                                               ,[Licence_Expiry_Date]
                                                               ,[Is_Available]
                                                               ,[Employ_Status]
                                                               ,[Phone_No]
                                                               ,[Mobile_No]
                                                               ,[Email]
                                                               ,[Address]
                                                               ,[Address2]
                                                               ,[Address3]
                                                               ,[Address4]
                                                               ,[City]
                                                               ,[SSS_ID]
                                                               ,[TAX_ID]
                                                               ,[Philhealth_ID]
                                                               ,[Role])
                                        VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}',
                                               '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')";
            query = string.Format(query, CommonUtilities.FormatString(employee.Code)
                                            , CommonUtilities.FormatString(employee.FirstName)
                                            , CommonUtilities.FormatString(employee.MiddleName)
                                            , CommonUtilities.FormatString(employee.LastName)
                                            , CommonUtilities.FormatString(employee.Nirc)
                                            , CommonUtilities.FormatString(employee.Nationality)
                                            , CommonUtilities.FormatString(employee.DrivingLicence)
                                            , CommonUtilities.FormatString(employee.DrivingClass)
                                            , CommonUtilities.ConvertDateForSQLPurpose(employee.LicenceExpiryDate)
                                            , employee.IsAvailable ? "T" : "F"
                                            , employee.EmployeeStatus == Employee_Status.Available ? "A" : "R"
                                            , CommonUtilities.FormatString(employee.Phone_no)
                                            , CommonUtilities.FormatString(employee.Mobile_no)
                                            , CommonUtilities.FormatString(employee.Email_add)
                                            , CommonUtilities.FormatString(employee.Address1)
                                            , CommonUtilities.FormatString(employee.Address2)
                                            , CommonUtilities.FormatString(employee.Address3)
                                            , CommonUtilities.FormatString(employee.Address4)
                                            , CommonUtilities.FormatString(employee.City)
                                            , CommonUtilities.FormatString(employee.SSS_ID)
                                            , CommonUtilities.FormatString(employee.Tax_ID)
                                            , CommonUtilities.FormatString(employee.Philhealth_ID)
                                            , employee.Role.GetHashCode());

            return query;
        }
        #endregion

        #region Customers and Operations

        public static string GetCustomerQuery(string code)
        {
            string query = @"select CustVend_Code as Code, CustVend_Name as Description, address1 as Address1, 
                                address2 as Address2, address3 as Address3, address4 as Address4
                                from ACT_CustVend_Master_Tbl
                                where CustVend_Code in (Select distinct Customer_Code from CRT_Operation_Database_Tbl)";
            if(!string.IsNullOrEmpty(code))
            {
                query += " AND Code = '{0}'";
                query = string.Format(query, CommonUtilities.FormatString(code));
            }
            return query;
        }

        public static string GetOperationQuery(string customerCode)
        {
            string query = @"Select distinct Operation_Code as Code, Operation_Name as Description, 
                                Op_add1 as Address1, Op_add2 as Address2, Op_add3 as Address3, Op_add4 as Address4, Operation_Type_Code 
                                from CRT_Operation_Database_Tbl where 1=1";
            if (!string.IsNullOrEmpty(customerCode))
            {
                query += " AND Customer_Code = '{0}'";
                query = string.Format(query, CommonUtilities.FormatString(customerCode));
            }
            return query;
        }




        #endregion
    }
}
