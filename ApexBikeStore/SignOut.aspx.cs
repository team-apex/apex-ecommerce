using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApexBikeStore
{
    public partial class SignOut : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check User login status
            if (Request.Cookies[".ASPXFORMSAUTH"] != null)
            {
                string user = Request.Cookies[".ASPXFORMSAUTH"].Name;
                UserDetails(user);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            #endregion
        }

        private void UserDetails(string user)
        {
            #region Get User

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user;

                    cmd.Connection = con;

                    // attempt to connect to server
                    try
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            lblMsg.Text = "Woops something went wrong! You don't seem to be signed in!";
                            //Response.Redirect("Login.aspx");
                        }
                        else
                        {
                            // request values from table
                            int customerId = Convert.ToInt32(reader["CustomerId"].ToString());}
                            string firstName = reader["FirstName"].ToString();

                            using (con)
                            {
                                using (SqlCommand cmd1 = new SqlCommand("Select_Cart", con))
                                {
                                    cmd1.CommandType = CommandType.StoredProcedure; 

                                    try
                                    {
                                        con.Open();
                                    }
                                    catch (Exception ex)
                                    {
                                        SqlDataReader r = cmd1.ExecuteReader();

                                        if (!r.HasRows)
                                        {
                                            lblMsg.Text =
                                                String.Format(
                                                    "Hey {0}, sorry to see you go! Don't worry though, we won't be going anywhere!",
                                                    firstName);
                                        }
                                        else
                                        {
                                            int count = Convert.ToInt32(r["Quantity"].ToString());

                                            lblMsg.Text =
                                                String.Format(
                                                    "Hey {0}, sorry to see you go! Don't worry though - " +
                                                    "the {1} items in your cart will be saved for later, " +
                                                    "and we won't be going anywhere!", firstName, count);
                                        }
                                    }
                                }
                               
                            }
                        }
                    catch (Exception ex)
                    {
                        throw new Exception("Error: " + ex.Message);
                    }
                    finally
                    {
                        // close connection
                        con.Close();   
                    }
                }
            }
            #endregion
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}