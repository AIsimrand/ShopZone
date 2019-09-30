using ShopZone.Helper;
using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Cart
{
    public partial class Confirmation : System.Web.UI.Page
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

            litTotalAmount.Text = string.Format("Rs. {0:0.00}", Math.Round(CartHelper.CurrentCart.Sum(i => i.TotalAmount), 2).ToString());

            litAddress1.Text = CartHelper.CurrentCart.FirstOrDefault().ShippingDetails.Address1;
            litAddress2.Text = CartHelper.CurrentCart.FirstOrDefault().ShippingDetails.Address2;
            litAddress2.Text = CartHelper.CurrentCart.FirstOrDefault().ShippingDetails.Address3;
            litCity.Text = CartHelper.CurrentCart.FirstOrDefault().ShippingDetails.City;
            litPincode.Text = CartHelper.CurrentCart.FirstOrDefault().ShippingDetails.Pincode;



        }
        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated && Session["UserInfo"] != null)
                Response.Redirect("~/Cart/Payment.aspx", false);
            else
                Response.Redirect("/Login.aspx?ReturnURL=/Cart/Payment.aspx", false);
        }


        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnApplyCoupon_Click(object sender, EventArgs e)
        {
            var couponsInfo = CouponManager.GetCouponByCode(txtCouponCode.Text);
            if (couponsInfo != null && couponsInfo.Discount > 0)
            {
                CartHelper.ApplyDiscount(couponsInfo.CouponCode, couponsInfo.Discount);
                BindShoppingCart();
            }
            else
            {
                litCouponMessage.Text = "Invalid Coupon!!!";
            }

        }
    }
}