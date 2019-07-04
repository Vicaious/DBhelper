using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public class DBhelper
    {
        public DataTable Cmd_Select(string connectstring,string sqlcmd)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection(connectstring);
            try
            {               
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sqlcmd;
                cmd.CommandType = CommandType.Text;
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
                return table;
            }
            catch(Exception e)
            {
                throw new Exception("DBHelper_Cmd_Select异常", e);
            }
            finally
            {
                con.Close();
            }           
        }

        public bool Cmd_Commit(string connectstring, string sqlcmd)
        {
            SqlConnection con = new SqlConnection(connectstring);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sqlcmd;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("DBHelper_Cmd_Commit异常", e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
