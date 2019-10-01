using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindOrderDetails();

            }
        }
        private void BindOrderDetails()
        {
            if (Request.QueryString["Id"] != null)
            {
                int orderId = Convert.ToInt32(Request.QueryString["Id"].ToString());
                var orderData = OrderManager.GetOrder(orderId);
                if (orderData != null)
                {
                    litProductName.Text = orderData.OrderProduct.Name;
                    imgProduct.Src = orderData.OrderProduct.ImageUrl;
                    litPrice.Text = string.Format("Rs. {0:0.00}", orderData.UnitAmount);
                    litUnit.Text = Convert.ToString(orderData.Unit);
                    litDiscount.Text = Convert.ToString(Math.Round(orderData.Discount, 2));
                    litAmountPaid.Text = string.Format("Rs. {0:0.00}", orderData.AmountPaid);
                    litPaymentMode.Text = orderData.PaymodeMode;
                    litPaymentStatus.Text = orderData.PaymentStatus;

                    var currentTransitData = orderData.OrderTrackingStatus.OrderByDescending(i => i.Id).FirstOrDefault();
                    if (currentTransitData != null)
                        ddlTransitStatus.SelectedValue = currentTransitData.TransitStatus;

                    Repeater1.DataSource = orderData.OrderTrackingStatus;
                    Repeater1.DataBind();
                }

            }
        }
        protected void btnUpdateTransit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int orderId = Convert.ToInt32(Request.QueryString["Id"].ToString());
                var orderData = OrderManager.GetOrder(orderId);
                var orderTrackingData = OrderManager.SaveOrderTracking(-1, orderData.CartGUID, ddlTransitStatus.SelectedValue);

                BindOrderDetails();
            }
        }
    }
}