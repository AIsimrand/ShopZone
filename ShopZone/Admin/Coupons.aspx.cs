using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Coupons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCoupons();
            }
        }

        private void BindCoupons()
        {
            Repeater1.DataSource = CouponManager.GetCoupons(isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }

        protected void imgButtonDelete_Click(object sender, EventArgs e)
        {
            int couponId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var coupon = CouponManager.GetCoupon(couponId, isActive: null, isDeleted: false);

            if (coupon != null)
            {
                coupon.IsDeleted = true;
                CouponManager.SaveCoupon(coupon);
                BindCoupons();
            }
        }

        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            int couponId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Admin/SaveCoupon.aspx?Id=" + couponId.ToString(), false);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/SaveCoupon.aspx?Id=-1", false);

        }
    }
}