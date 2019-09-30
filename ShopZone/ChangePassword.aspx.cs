using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            var result = AccountManager.UpdatePassword(txtUsername.Text, txtCurrentPassword.Text, txtNewPassword.Text);
            if (result)
            {
                litMessage.Text = "Password changed successfully!!!";
            }
            else
            {
                litMessage.Text = "Password changed failed!!!";
            }
        }


    }
}