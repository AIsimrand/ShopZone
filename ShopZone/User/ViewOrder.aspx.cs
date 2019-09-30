using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.User
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
                string transactionId = Convert.ToString(Request.QueryString["Id"].ToString());
                var orderData = OrderManager.GetOrders(transactionId);
                if (orderData != null)
                {
                    rptProduct.DataSource = orderData;
                    rptProduct.DataBind();
                    //litProductName.Text = orderData.OrderProduct.Name;
                    //imgProduct.Src = orderData.OrderProduct.ImageUrl;
                    //litPrice.Text = string.Format("Rs. {0:0.00}", orderData.UnitAmount);
                    //litUnit.Text = Convert.ToString(orderData.Unit);
                    //litDiscount.Text = Convert.ToString(Math.Round(orderData.Discount, 2));
                    //litAmountPaid.Text = string.Format("Rs. {0:0.00}", orderData.AmountPaid);
                    //litPaymentMode.Text = orderData.PaymodeMode;
                    //litPaymentStatus.Text = orderData.PaymentStatus;

                  
                    //Repeater1.DataSource = orderData.OrderTrackingStatus;
                    //Repeater1.DataBind();
                }

            }
        }
       
    }
}