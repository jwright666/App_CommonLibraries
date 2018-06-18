using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.DALHelper
{
    public class DBConnection
    {
        private string connString;

        public DBConnection() { }

        public static readonly DBConnection TheInstance = new DBConnection(); //for singleton

        public string GetConnectionString()
        {
            try
            {
                if (string.IsNullOrEmpty(connString))
                    throw new Exception("Please setup connection string first.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message.ToString());
            }
            return connString;
        }

        public void SetConnectionString()
        {
            try
            {
                connString = ConfigurationManager.ConnectionStrings["jwrightConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception("Error accesing database.\n" + ex.InnerException.Message.ToString());
            }
        }

        public void SetConnectionString(string conString)
        {
            try
            {
                connString = conString;
            }
            catch (Exception ex)
            {
                throw new Exception("Error accesing database.\n" + ex.InnerException.Message.ToString());
            }
        }

        public void SetConnectionString(string server, string dbName, string sqlUserName, string sqlUserPassword)
        {
            try
            {
                connString = "Data Source= '{0}'; Initial Catalog='{1}';  User Id = '{2}'; password = '{3}';";
                connString = string.Format(connString, server, dbName, sqlUserName, sqlUserPassword);
            }
            catch (Exception ex)
            {
                throw new Exception("Error accesing database.\n" + ex.InnerException.Message.ToString());
            }
        } 
    }
}
