using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApexBikeStore
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Check User login status
            if (Request.Cookies[".ASPXFORMSAUTH"] != null)
            {
                lblMessage.Text = "Sup";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            #endregion
        }
    }
}