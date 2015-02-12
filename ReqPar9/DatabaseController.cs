using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ReqPar9
{
    class DatabaseController
    {
        string connString = "Server=ealdb1.eal.local;" + "Database=EJL100_DB;" + "User Id=ejl100_usr;" + "Password=Baz1nga100";

        public SqlDataReader GetYeast()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetYeast", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public SqlDataReader GetMalt()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetMalt", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public SqlDataReader GetHop()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetHop", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
