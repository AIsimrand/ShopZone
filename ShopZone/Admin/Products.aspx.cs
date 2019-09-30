using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            Repeater1.DataSource = ProductManager.GetProducts(isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }

        protected void imgButtonDelete_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var product = ProductManager.GetProduct(productId, isActive: null, isDeleted: false);

            if (product != null)
            {
                product.IsDeleted = true;
                ProductManager.SaveProduct(product);
                BindProducts();
            }
        }

        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Admin/SaveProduct.aspx?Id=" + productId.ToString(), false);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/SaveProduct.aspx?Id=-1", false);

        }
    }
}