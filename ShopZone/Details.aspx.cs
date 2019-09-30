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
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindProductDetails();
            }
        }

        private void BindProductDetails()
        {
            int productId = 0;
            if (Request.QueryString["Id"] != null && int.TryParse(Request.QueryString["Id"], out productId))
            {

                 productId = Convert.ToInt32( Request.QueryString["Id"].ToString());
                 var productItem = ProductManager.GetProduct(productId, true, false);

                imgProductImage.Src = productItem.ImageUrl;
                litPrice.Text = string.Format("Rs. {0:0.00}", productItem.Price);
                litName.Text = productItem.Name;
                litDescription.Text = productItem.Description;
                if (productItem.NoOfStock <= 0)
                {
                    lBtnAddToCart.Attributes.CssStyle.Add("display", "none");
                    btnOutOfStock.Attributes.CssStyle.Add("display", "block");
                }
                else
                {
                    btnOutOfStock.Attributes.CssStyle.Add("display", "none");
                    lBtnAddToCart.Attributes.CssStyle.Add("display", "block");
                }
            }
        }

        protected void lBtnAddToCart_Click(object sender, EventArgs e)
        {
            int productId = 0;
            if (Request.QueryString["Id"] != null && int.TryParse(Request.QueryString["Id"], out productId))
            {
                CartHelper.AddToCart(productId);
                Literal literalCart = (Literal)Page.Master.FindControl("litCartItemCount");
                if (literalCart != null)
                {
                    literalCart.Text = CartHelper.CurrentCart.Count().ToString();
                }
            }
        }
    }
}