using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ReqPar9
{
    static public class DatabaseController
    {
        static string connString = "Server=ealdb1.eal.local;" + "Database=EJL100_DB;" + "User Id=ejl100_usr;" + "Password=Baz1nga100";

        static public List<Yeast> GetYeast()
        {
            List<Yeast> yeasts = new List<Yeast>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetYeast", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    yeasts.Add(new Yeast(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["Attenuation"].ToString()));
                    }
                    return yeasts;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
       static public List<Malt> GetMalt()
        {
            List<Malt> malts = new List<Malt>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetMalt", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        malts.Add(new Malt(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["EBC"].ToString(), reader["Mash"].ToString()));
                    }
                    return malts;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        static public List<Hop> GetHop()
        {
            List<Hop> hops = new List<Hop>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_GetHop", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hops.Add(new Hop(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["Alpha"].ToString()));
                    }
                    return hops;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
