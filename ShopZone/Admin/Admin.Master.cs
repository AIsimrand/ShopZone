using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] != null)
            {
                litUsername.Text = ((LoginUser)Session["UserInfo"]).EmailId;
            }
            else
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx", false);

            }
        }

        protected void hlnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx", false);
        }
    }
}