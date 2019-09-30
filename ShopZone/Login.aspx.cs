using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopZone.Entity;
using ShopZone.Manager;

namespace ShopZone
{
    public partial class Login : System.Web.UI.Page
    {
        String returnUrl1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetReturnUrl(null);
            }
        }
        private string SetReturnUrl(LoginUser user)
        {
            // 4. Do the redirect. 
            String returnUrl1;
            // the login is successful
            if (Request.QueryString["ReturnUrl"] == null && user != null)
            {
                if (user.UserRole.Name.ToUpper() == "ADMIN")
                    returnUrl1 = "~/Admin/Dashboard.aspx";
                else
                    returnUrl1 = "~/User/MyOrders.aspx";

            }

            //login not unsuccessful 
            else
            {
                returnUrl1 = Request.QueryString["ReturnUrl"];
            }

            Session["ReturnURL"] = returnUrl1;
            return returnUrl1;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var user = AccountManager.ValidateCredentials(txtUsername.Text, txtPassword.Text);

            if (user != null && user.Id > 0)
            {
                AccountManager.AuthenticateUser(user.EmailId, user.Password, chkRemmemberMe.Checked);

                returnUrl1 = SetReturnUrl(user);
                Response.Redirect(returnUrl1);
            }
            else
            {
                lblMessage.Text = "Invalid Email Id and Password";
            }
        }




    }
}