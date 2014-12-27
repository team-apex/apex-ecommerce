using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApexBikeStore.Models;

namespace ApexBikeStore
{
    public partial class Apex : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            //Product product = new Product();

            //// store filter term in session
            //Session["term"] = txtFilter.Text;

            //Response.Redirect("Search.aspx");

        }
    }
}