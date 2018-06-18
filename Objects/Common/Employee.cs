using App_CommonLibraries.DALHelper;
using App_CommonLibraries.Utilities;
using App_CommonLibraries.Utilities.CommonEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.Objects.Common
{
    public class Employee : INotifyPropertyChanged
    {
        [DataNames("Code", "code")]
        public string Code { get; set; }
        [DataNames("FirstName", "firstName", "first_name")]
        public string FirstName { get; set; }
        [DataNames("MiddleName", "middleName", "middle_name")]
        public string MiddleName { get; set; }
        [DataNames("LastName", "lastName", "last_name")]
        public string LastName { get; set; }
        [DataNames("Nirc", "nirc", "NRIC")]
        public string Nirc { get; set; }
        [DataNames("Nationality", "nationality")]
        public string Nationality { get; set; }
        [DataNames("Phone_no", "phone_no")]
        public string Phone_no { get; set; }
        [DataNames("Mobile_no", "mobile_no")]
        public string Mobile_no { get; set; }
        [DataNames("Email_add", "email_add")]
        public string Email_add { get; set; }
        [DataNames("Address1", "address1", "Add", "Address")]
        public string Address1 { get; set; }
        [DataNames("Address2", "address2", "Add2")]
        public string Address2 { get; set; }
        [DataNames("Address3", "address3", "Add3")]
        public string Address3 { get; set; }
        [DataNames("Address4", "address4", "Add4")]
        public string Address4 { get; set; }
        [DataNames("City", "city")]
        public string City { get; set; }
        [DataNames("IsAvailable", "isAvailable")]
        public bool IsAvailable { get; set; }
        [DataNames("EmployeeStatus", "employeeStatus")]
        public Employee_Status EmployeeStatus { get; set; }
        [DataNames("DrivingLicence", "drivingLicence")]
        public string DrivingLicence { get; set; }
        [DataNames("DrivingClass", "drivingClass")]
        public string DrivingClass { get; set; }
        [DataNames("LicenceExpiryDate", "licenceExpiryDate")]
        public DateTime LicenceExpiryDate { get; set; }
        //for philippines
        [DataNames("SSS_ID", "SSS_ID", "SSSID")]
        public string SSS_ID { get; set; }
        [DataNames("Tax_ID", "tax_ID", "TaxID")]
        public string Tax_ID { get; set; }
        [DataNames("Philhealth_ID", "philhealth_ID")]
        public string Philhealth_ID { get; set; }
        [DataNames("Role", "role")]
        public Designation Role { get; set; }

        #region PropertyChangedEventHandler member
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        public static DataSet GetEmployees()
        {
            DataSet ds = null;
            try
            {
                DataTable dt = CommonDAL.GetData(CommonSQLStrings.GetEmployeesQuery());
                ds = new DataSet();
                ds.Tables.Add(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
            return ds;
        }

        public static void UpdateEmployee(Employee employee)
        {
            try
            {
                CommonDAL.UpdateData(CommonSQLStrings.UpdateEmployeeQuery(employee));
            }
            catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
        }
        internal static void UpdateData(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.TheInstance.GetConnectionString()))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    CommonDAL.UpdateData(CommonSQLStrings.UpdateEmployeeQuery(employee), con, tran);
                    tran.Commit();
                }
                catch (Exception ex) { if (tran != null) { tran.Rollback(); } throw new Exception(ex.Message.ToString()); }
                finally { con.Close(); }
            }
        }
    }
}
