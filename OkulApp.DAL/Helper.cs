using System;
using System.Data.SqlClient;
using System.Configuration;

namespace OkulApp.DAL
{
    public class Helper : IDisposable
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;
        private static Helper Instance2;
        private Helper()
        {

        }
        public static Helper Instance
        {
            get
            {
                if (Instance2 == null)
                {
                    Instance2 = new Helper();
                }
                return Instance2;
            }
        }
        public void Dispose()
        {
            if (cn != null)
            {
                cn.Dispose();
            }

            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            using (cn = new SqlConnection(cstr))
            {
                using (cmd = new SqlCommand(cmdtext, cn))
                {
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            cn = new SqlConnection(cstr);

            cmd = new SqlCommand(cmdtext, cn);
                
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
        }
   