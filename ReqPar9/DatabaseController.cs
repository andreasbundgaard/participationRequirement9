using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ReqPar9
{
    public class DatabaseController
    {
        static string connString = "Server=ealdb1.eal.local;" + "Database=EJL100_DB;" + "User Id=ejl100_usr;" + "Password=Baz1nga100";

        public void CreateRecipe(string Name, int YeastID, int Efficiency, int Attnuation, int FinalGravity, int BoilVolume, int Contents, int Volume)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sadr0007_SP_CreateRecipe", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Name", Name));
                    cmd.Parameters.Add(new SqlParameter("@YeastID", YeastID));
                    cmd.Parameters.Add(new SqlParameter("@Efficiency", Efficiency));
                    cmd.Parameters.Add(new SqlParameter("@Attnuation", Attnuation));
                    cmd.Parameters.Add(new SqlParameter("@FinalGravity", FinalGravity));
                    cmd.Parameters.Add(new SqlParameter("@BoilVolume", BoilVolume));
                    cmd.Parameters.Add(new SqlParameter("@Contents", Contents));
                    cmd.Parameters.Add(new SqlParameter("@Volume", Volume));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
        }

        public void CreateRecipeHop(int RawMaterialID, int Quantity, int BoilTime)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sadr0007_SP_CreateRecipeHop", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RawMaterialID", RawMaterialID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
                    cmd.Parameters.Add(new SqlParameter("@BoilTime", BoilTime));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
        }

        public void CreateRecipeMalt(int RawMaterialID, int Quantity)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sadr0007_SP_CreateRecipeMalt", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RawMaterialID", RawMaterialID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", Quantity));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
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
                    SqlCommand cmd = new SqlCommand("sadr0007_SP_GetHop", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        hops.Add(new Hop(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["Alpha"].ToString()));
                    }
                    return hops;
                }
                catch (Exception e)
                {
                    throw e;
                } 
                finally
                {
                    conn.Dispose();
                    conn.Close();
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
                    SqlCommand cmd = new SqlCommand("sadr0007_SP_GetMalt", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        malts.Add(new Malt(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["EBC"].ToString(), reader["Mash"].ToString()));
                    }
                    return malts;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
        }

       static public List<Yeast> GetYeast()
       {
           List<Yeast> yeasts = new List<Yeast>();
           using (SqlConnection conn = new SqlConnection(connString))
           {
               try
               {
                   conn.Open();
                   SqlCommand cmd = new SqlCommand("sadr0007_SP_GetYeast", conn);
                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                       yeasts.Add(new Yeast(reader["Name"].ToString(), reader["Quantity"].ToString(), reader["RawMaterialID"].ToString(), reader["Threshold"].ToString(), reader["Attenuation"].ToString()));
                   }
                   return yeasts;
               }
               catch (Exception e)
               {
                   throw e;
               }
               finally
               {
                   conn.Dispose();
                   conn.Close();
               }
           }
       }
    }
}