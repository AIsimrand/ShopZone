using ShopZone.Entity;
using ShopZone.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Cart
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            var cart = CartHelper.CurrentCart;

            var transactionGuid = Guid.NewGuid();
            foreach (var item in cart)
            {
                item.CartGUID = transactionGuid.ToString();
                item.PaymentMode = rbtnPaymentMode.SelectedValue.ToString();
                item.PaymentStatus = "SUCCESS";

            }

            CartHelper.CurrentCart = cart;

            var orders = CartHelper.PlaceOrder(cart);
            var userInfo = (LoginUser)Session["UserInfo"];
            //EmailHelper.SendMail(userInfo.EmailId, "admin@shopzone.com", "", "Shopezone Order Placed", "You have placed you order for " + orders.FirstOrDefault().OrderProduct.Name);
            
            EmailHelper.SendMail("simrand108@gmail.com", "admin@shopzone.com", "", "Shopezone Order Placed", "You have placed you order for " + orders.FirstOrDefault().OrderProduct.Name);
            Response.Redirect("~/User/ViewOrder.aspx?Id=" + orders.FirstOrDefault().CartGUID, false);
        }

        protected void btnCancelPayment_Click(object sender, EventArgs e)
        {
            var cart = CartHelper.CurrentCart;
            foreach (var item in cart)
            {
                item.PaymentMode = rbtnPaymentMode.SelectedValue.ToString();
                item.PaymentStatus = "FAIL";

            }

            CartHelper.CurrentCart = cart;

            var orders = CartHelper.PlaceOrder(cart);

            Response.Redirect("~/User/MyOrders.aspx", false);
        }
    }
}