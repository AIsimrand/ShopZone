using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Orders : System.Web.UI.Page
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
            Repeater1.DataSource = OrderManager.GetOrders(null, isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }

        protected void imgBtnView_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Admin/ViewOrder.aspx?Id=" + productId.ToString(), false);

        }

    }
}