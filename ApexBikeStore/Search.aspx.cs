using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApexBikeStore.Models;

namespace ApexBikeStore
{
    // i was not allowed to use the search bar from the master page to filter as it has to be inside a form run at the server
    public partial class Search : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string searchTerm = Session["term"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select ProductName, Price from Customers where ProductName=@Name", con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Name", searchTerm);

                    try
                    {
                        con.Open();

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            var productName = row["ProductName"].ToString();
                            var price = row["Price"].ToString();

                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}