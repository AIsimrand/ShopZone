using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity = ShopZone.Entity;

namespace ShopZone
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    throw new ArgumentException("Passwords do not match!!!");
                }

                var user = new LoginUser
                {
                    EmailId = txtEmailId.Text,
                    Password = txtPassword.Text,
                    SecurityQuestion = txtSecurityQuestion.Text,
                    SecurityAnswer = txtSecurityAnswer.Text

                };
                var customer = new Customer
                {
                    LoginInfo = user,
                    Address1 = txtAddress1.Text,
                    Address2 = txtAddress2.Text,
                    Address3 = string.Empty,
                    City = txtCity.Text,
                    Pincode = txtPincode.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,


                };
                AccountManager.RegisterUser(customer);
                litMessage.Text = "User registered successfully!!!";

                user = AccountManager.AuthenticateUser(user.EmailId, user.Password, true);

                var returnUrl1 = "~/Index.aspx";
                if (Session["ReturnURL"] == null)
                {


                    if (user.UserRole.Name.ToUpper() == "ADMIN")
                        returnUrl1 = "~/Admin/Dashboard.aspx";
                }
                else
                {
                    returnUrl1 = (string)Session["ReturnURL"];
                }

                Response.Redirect(returnUrl1, false);

            }
            catch (ArgumentException ex)
            {
                litMessage.Text = ex.Message;
            }
            catch (Exception ex)
            {
                litMessage.Text = ex.Message;
            }
        }


    }
}