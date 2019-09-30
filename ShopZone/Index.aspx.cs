using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopZone.Manager;
using Model = ShopZone.Entity;
using System.Web.UI.HtmlControls;
using ShopZone.Helper;

namespace ShopZone
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindProduct();

            }
        }
        private void BindProduct()
        {
            var products = ProductManager.GetProducts(true, false).Where(i => i.HasOffer == true).ToList();

            rptProduct2.DataSource = products;
            rptProduct2.DataBind();
            rptProduct.DataSource = ProductManager.GetProducts(true, false).Where(i => i.HasOffer == false).ToList();
            rptProduct.DataBind();
        }

        protected void rptProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlImage imgProductImage = (HtmlImage)e.Item.FindControl("imgProductImage");
                Literal litPrice = (Literal)e.Item.FindControl("litPrice");
                Literal litReducedPrice = (Literal)e.Item.FindControl("litReducedPrice");
                Literal litName = (Literal)e.Item.FindControl("litName");
                Literal litDescription = (Literal)e.Item.FindControl("litDescription");
                LinkButton lBtnAddToCart = (LinkButton)e.Item.FindControl("lBtnAddToCart");
                Button btnOutOfStock = (Button)e.Item.FindControl("btnOutOfStock");

                Entity.Product productItem = (Entity.Product)e.Item.DataItem;
                imgProductImage.Src = productItem.ImageUrl;
                litPrice.Text = string.Format("Rs. {0:0.00}", productItem.Price);
                litReducedPrice.Text = string.Format("Rs. {0:0.00}", (productItem.Price * 1.10M));
                litName.Text = productItem.Name;
                if (productItem.Description.Length >= 31)
                {
                    litDescription.Text = productItem.Description.Substring(0, 30) + "...";
                }
                else
                {
                    litDescription.Text = productItem.Description;
                }

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

        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ADD_TO_CART")
            {
                AddItemToCart(Convert.ToInt32(e.CommandArgument));
            }
        }
        private void AddItemToCart(int productId)
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