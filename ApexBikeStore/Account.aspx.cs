using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevOne.Security.Cryptography.BCrypt;

namespace ApexBikeStore
{
    public partial class Account : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            GetUserDetails();
        }

        private void GetUserDetails()
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
                            // get password
                            string hashedPassword = reader["Password"].ToString();

                            // compare passwords
                            bool check = BCryptHelper.CheckPassword(txtPassword.Text, hashedPassword);

                            if (check == true)
                            {
                                UpdatePassword(txtNewPassword.Text, user);
                            }
                            else
                            {
                                lblMsg.Text = "Incorrect Password!";
                            }
                    
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error: " + ex.Message);
                    }
                }
            }
            #endregion
        }

        private void UpdatePassword(string newPassword, string user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Update_Password", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Email", user);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    cmd.Connection = con;

                    // try update
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        lblMsg.Text = "Password update successful!";
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Update Error: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        #region Hashing Password
        // Bcrypt hashing function
        public static string GetRandomSalt()
        {
            string salt = BCryptHelper.GenerateSalt(12);
            return salt;
        }

        public static string CreateHash(string password)
        {
            string hash = BCryptHelper.HashPassword(password, GetRandomSalt());
            return hash;
        }
        #endregion
    }

}