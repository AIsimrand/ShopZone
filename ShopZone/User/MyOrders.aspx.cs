using ShopZone.Entity;
using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.User
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            var loginUser = (LoginUser)Session["UserInfo"];

            var myOrder = OrderManager.GetOrders(null, isActive: null, isDeleted: false)
                .Where(i => i.Customer.LoginInfo.Id == loginUser.Id)
                .ToList();
            Repeater1.DataSource = myOrder;
            Repeater1.DataBind();
        }
        protected void imgBtnView_Click(object sender, EventArgs e)
        {
            string productId = Convert.ToString(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/User/ViewOrder.aspx?Id=" + productId, false);

        }
    }
}