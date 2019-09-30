using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = AccountManager.GetUser(hdnUsername.Value);
            if (result != null)
            {
                if(result.LoginInfo.SecurityAnswer == txtSecurityAnswer.Text)
                {

                    //TODO: Need to write send email code here
                    litMessage2.Text = "Your password is sent to you on your registered email id.";
                }
            }
            else
            {
                litMessage1.Text = "Username not found!!!";
            }
        }
        protected void btnRetrievePassword_Click(object sender, EventArgs e)
        {
            var result = AccountManager.GetUser(txtUsername.Text);
            if (result != null)
            {
                divGetSecurityQuestion.Visible = false;
                divSecurityQuestion.Visible = true;
                txtSecurityQuestion.Text = result.LoginInfo.SecurityQuestion;
                hdnUsername.Value = result.LoginInfo.EmailId;
                txtSecurityQuestion.Enabled = false;
            }
            else
            {
                litMessage1.Text = "Username not found!!!";
            }
        }
    }
}