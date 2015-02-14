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
                    yeasts.Add(new Yeast(
                        reader["Name"].ToString(), 
                        reader["Quantity"].ToString(), 
                        reader["RawMaterialID"].ToString(), 
                        reader["Threshold"].ToString(), 
                        reader["Attenuation"].ToString()
                    ));
                    }
                    return yeasts;
                }
                catch (SqlException)
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
                        malts.Add(new Malt(
                            reader["Name"].ToString(), 
                            reader["Quantity"].ToString(), 
                            reader["RawMaterialID"].ToString(), 
                            reader["Threshold"].ToString(), 
                            reader["EBC"].ToString(), 
                            reader["Mash"].ToString()
                        ));
                    }
                    return malts;
                }
                catch (SqlException)
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
                        hops.Add(new Hop(
                            reader["Name"].ToString(), 
                            reader["Quantity"].ToString(), 
                            reader["RawMaterialID"].ToString(), 
                            reader["Threshold"].ToString(), 
                            reader["Alpha"].ToString()
                        ));
                    }
                    return hops;
                }
                catch (SqlException)
                {

                    throw;
                }
            }
        }
        static public int CreateRecipe(Recipe recipe)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_CreateRecipe", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter();
                    cmd.Parameters.Add(new SqlParameter("@Name", recipe.Name));
                    cmd.Parameters.Add(new SqlParameter("@YeastID", recipe.YeastID));
                    cmd.Parameters.Add(new SqlParameter("@Efficiency", recipe.Efficiency));
                    cmd.Parameters.Add(new SqlParameter("@Attnuation", recipe.Attnuation));
                    cmd.Parameters.Add(new SqlParameter("@BoilVolume", recipe.BoilVolume));
                    cmd.Parameters.Add(new SqlParameter("@Contents", recipe.Contents));
                    cmd.Parameters.Add(new SqlParameter("@Volume", recipe.Volume));
                    cmd.Parameters.Add(new SqlParameter("@FinalGravity", recipe.FinalGravity));

                    return recipe.RecipeID = (int)cmd.ExecuteScalar();

                }
                catch (SqlException)
                {
                    
                    throw;
                }
            }
        }

        static public void CreateRecipeHop(Hop hop, int recipeID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_CreateRecipeHop", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter();
                    cmd.Parameters.Add(new SqlParameter("@RecipeID", recipeID));
                    cmd.Parameters.Add(new SqlParameter("@RawMaterialID", hop.RawMaterialID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", hop.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@Boiltime", hop.BoilTime));
                    
                    cmd.BeginExecuteNonQuery();
                }
                catch (SqlException)
                {

                    throw;
                }
            }
        }
        static public void CreateRecipeMalt(Malt malt, int recipeID)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("jens3737_SP_CreateRecipeMalt", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter();
                    cmd.Parameters.Add(new SqlParameter("@RecipeID", recipeID));
                    cmd.Parameters.Add(new SqlParameter("@RawMaterialID", malt.RawMaterialID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", malt.Quantity));

                    cmd.BeginExecuteNonQuery();
                }
                catch (SqlException)
                {

                    throw;
                }
            }
        }
    }
}
