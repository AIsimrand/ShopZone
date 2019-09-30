using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class SaveCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"].ToString());

                if (id > 0)
                {
                    BindCouponDetails(id);
                }
            }
        }


        private void BindCouponDetails(int id)
        {
            var cat = CouponManager.GetCoupon(id, isActive: null, isDeleted: false);
            if (cat != null)
            {
                txtName.Text = cat.Name;
                txtDescription.Text = cat.Description;
                txtCode.Text = cat.CouponCode;
                txtDiscount.Text = string.Format("{0:0.00}", cat.Discount);
                chkIsActive.Checked = cat.IsActive;


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            var cat = new Coupon();
            if (id > 0)
            {
                cat = CouponManager.GetCoupon(id, isActive: null, isDeleted: false);

            }

            cat.Name = txtName.Text;
            cat.Description = txtDescription.Text;
            cat.CouponCode = txtCode.Text;
            cat.Discount = Convert.ToDecimal(txtDiscount.Text);
            cat.IsActive = chkIsActive.Checked;

            CouponManager.SaveCoupon(cat);

            Response.Redirect("~/Admin/Coupons.aspx", false);
        }
    }
}