using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApexBikeStore
{
    public partial class Home : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check User login status
            if (Request.Cookies[".ASPXFORMSAUTH"] != null)
            {
                UserDetails();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            #endregion
        }

        private void UserDetails()
        {
            string user = Context.User.Identity.Name;

            #region Pull user details

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user;

                    cmd.Connection = con;

                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var firstName = reader["FirstName"].ToString();
                            var isConfirmed = reader["EmailVerified"].ToString();
                            bool emailConfirmed = Convert.ToBoolean(isConfirmed);

                            Display(firstName, emailConfirmed);

                        }
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("Error: " + ex.Message);
                    }
                }
            }
            #endregion


        }

        private void Display(string firstName, bool isConfirmed)
        {
            lblWelcome.Text = String.Format("Welcome {0}!", firstName);

            if(isConfirmed != true)
            {
                lblMessage.Text = String.Format("It appears you have not yet confirmed your email with us, " +
                                                "in order to provide a unique user experience please do this now " +
                                                "(or whenever you can).");
            }
        }
    }
}