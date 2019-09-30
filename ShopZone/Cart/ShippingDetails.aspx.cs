using ShopZone.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Cart
{
    public partial class ShippingDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var cart = CartHelper.CurrentCart;
            foreach (var item in cart)
            {
                item.ShippingDetails = new Entity.ShippingAddress
                {
                    Address1 = txtAddress1.Text,
                    Address2 = txtAddress2.Text,
                    //item.ShippingDetails.Address3 = txtAddress3.Text,
                    City = txtCity.Text,
                    Pincode = txtPincode.Text
                };

            }

            CartHelper.CurrentCart = cart;


            Response.Redirect("~/Cart/Confirmation.aspx");

        }
    }
}