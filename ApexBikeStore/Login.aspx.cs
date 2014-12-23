using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevOne.Security.Cryptography.BCrypt;

namespace ApexBikeStore
{
    public partial class Login : System.Web.UI.Page
    {
        // connection to database
        static string connectionString = WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check Existing Login status
            // user already logged in
            if (Request.Cookies[".ASPXFORMSAUTH"] != null)
            {
                // bring to sign out page
                Response.Redirect("SignOut.aspx");
            }
            #endregion
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            #region Login form reads

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            #endregion

            #region Login User

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Connection = con;
                    //var hashedPassword = new SqlParameter("@Password", SqlDbType.Char);
                    //hashedPassword.Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add(hashedPassword);

                    try
                    {
                        // open connection
                        con.Open();

                        // read rows from database
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            lblMsgLog.Text = "A user with this e-mail does not exist.";
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                // get password
                                string hashedPassword = reader["Password"].ToString();

                                // compare passwords
                                bool check = BCryptHelper.CheckPassword(password, hashedPassword);

                                if (check == true)
                                {
                                    // login successful
                                    FormsAuthentication.RedirectFromLoginPage(email, cbxRemember.Checked);

                                    //LoginUser(email);

                                }
                                else
                                {
                                    lblMsgLog.Text = "Incorrect Password!";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Login Error: " + ex.Message);
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            #region Registration form reads

            string firstName = txtFname.Text;
            string lastName = txtLname.Text;
            string email = txtEmailReg.Text;
            string password = txtPasswordReg.Text;
            string passwordConfirm = txtPasswordConfirm.Text;
            string hashedPassword = CreateHash(password);
            string gender = rbnGender.SelectedValue;
            DateTime dateOfBirth = Convert.ToDateTime(txtDob.Text);

            #endregion

            #region Insert Customer

            if (password == passwordConfirm)
            {
                // return value from sql
                int result = 0;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_User", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = hashedPassword;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;

                        cmd.Connection = con;

                        try
                        {
                            con.Open();
                            result = Convert.ToInt32(cmd.ExecuteScalar());

                            if (result == -1)
                            {
                                lblMsgReg.Text = "Oops! A user with this e-mail already exists!";
                            }
                            else
                            {
                                // login successful
                                FormsAuthentication.RedirectFromLoginPage(email, cbxRemember.Checked);

                                //LoginUser(email);

                                //HttpCookie cookie = FormsAuthentication.GetAuthCookie(email, cbxRememberMe.Checked);
                                //Response.Cookies.Add(cookie);
                                //Response.Redirect("Home.aspx");

                                //string userData = "ApplicationSpecific data for this user.";

                                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                //  email,
                                //  DateTime.Now,
                                //  DateTime.Now.AddMinutes(30),
                                //  cbxRememberMe.Checked,
                                //  userData,
                                //  FormsAuthentication.FormsCookiePath);

                                //// Encrypt the ticket.
                                //string encTicket = FormsAuthentication.Encrypt(ticket);

                                //// Create the cookie.
                                //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                                //// Redirect back to original URL.
                                //Response.Redirect(FormsAuthentication.GetRedirectUrl(email, cbxRememberMe.Checked));
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
            #endregion
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


        //public void LoginUser(string email)
        //{
        //    string userData = "ApplicationSpecific data for this user.";

        //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        //      email,
        //      DateTime.Now,
        //      DateTime.Now.AddMinutes(30),
        //      isPersistent,
        //      userData,
        //      FormsAuthentication.FormsCookiePath);

        //    // Encrypt the ticket.
        //    string encTicket = FormsAuthentication.Encrypt(ticket);

        //    // Create the cookie.
        //    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

        //    // Redirect back to original URL.
        //    Response.Redirect(FormsAuthentication.GetRedirectUrl(email, isPersistent));

        //}

    }
}