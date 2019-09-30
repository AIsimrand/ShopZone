using ShopZone.Helper;
using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindShoppingCart();
            }
        }

        private void BindShoppingCart()
        {
            rptProduct.DataSource = CartHelper.CurrentCart;
            rptProduct.DataBind();
        }

        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var product = CartHelper.RemoveFromCart(productId);

           
            BindShoppingCart();
        }

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            if (CartHelper.CurrentCart.Any())
                Response.Redirect("~/Cart/ShippingDetails.aspx", false);
            else
            {
                litMessage.Text = "Sorry, No items in Cart!!!";
            }

        }
    }
}