using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CommonLibraries.DALHelper
{
    internal class CommonDAL
    {
        internal static DataTable FetchSearchData(string tableName, int rowCount)
        {
            DataTable retValue = null;
            using (SqlConnection con = new SqlConnection(DBConnection.TheInstance.GetConnectionString()))
            {
                try
                {
                    string query = @"SELECT {0} * FROM " + tableName;
                    if (rowCount > 0)
                        query = string.Format(query, " TOP " + rowCount.ToString());
                    else
                        query = string.Format(query, string.Empty);

                    SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                    con.Open();
                    retValue = new DataTable();
                    adpt.Fill(retValue);
                }
                catch (SqlException ex) { throw new Exception(ex.Message.ToString()); }
                catch (InvalidOperationException ex) { throw new Exception(ex.Message.ToString()); }
                catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
                finally { con.Close(); }
            }
            return retValue;        
        }
        internal static DataTable GetData(string query)
        {
            DataTable retValue = null;
            using (SqlConnection con = new SqlConnection(DBConnection.TheInstance.GetConnectionString()))
            {
                try
                {
                    SqlDataAdapter adpt = new SqlDataAdapter(query, con);
                    con.Open();
                    retValue = new DataTable();
                    adpt.Fill(retValue);
                }
                catch (SqlException ex) { throw new Exception(ex.Message.ToString()); }
                catch (InvalidOperationException ex) { throw new Exception(ex.Message.ToString()); }
                catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
                finally { con.Close(); }
            }
            return retValue;
        }
        internal static void UpdateData(string query)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.TheInstance.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) { throw new Exception(ex.Message.ToString()); }
                catch (InvalidOperationException ex) { throw new Exception(ex.Message.ToString()); }
                catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
                finally { con.Close(); }
            }
        }
        internal static void UpdateData(string query, SqlConnection con, SqlTransaction tran)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cmd.Transaction = tran;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new Exception(ex.Message.ToString()); }
            catch (InvalidOperationException ex) { throw new Exception(ex.Message.ToString()); }
            catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
        }
   

        //for objects


    }
}

