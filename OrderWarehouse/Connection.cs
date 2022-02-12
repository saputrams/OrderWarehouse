using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OrderWarehouse
{
    public class Connection
    {
        public DataTable ExecQuery(string sql)
        {
            string conn = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection db = new SqlConnection(conn);
            db.Open();
            
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            db.Close();

            return dt;
        }

        public DataTable ExecProcedure(string strName, ListDictionary lstParams)
        {
            string conn = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand(strName))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach(DictionaryEntry entry in lstParams)
                    {
                        cmd.Parameters.AddWithValue(entry.Key.ToString(), entry.Value.ToString());
                    }
                    cmd.Connection = con;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
                    try
                    {
                        da.Fill(dt);
                    }
                    catch
                    {
                        return null;
                    }
                    con.Close();
                    con.Dispose();
                }
            }
            return dt;
        }
    }
}