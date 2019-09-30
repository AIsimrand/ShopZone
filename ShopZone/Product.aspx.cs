using ShopZone.Helper;
using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShopZone
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindInfo();
                BindProduct();
            }
        }

        private void BindInfo()
        {
            var searchType = "Products";
            if (Request.QueryString["SearchType"] != null)
            {
                searchType = Request.QueryString["SearchType"].ToString();
            }
            if (Request.QueryString["q"] != null)
            {
              
                var filterText = Request.QueryString["q"].ToString();
                searchType = "SEARCH \"" + filterText + "\"";
                TextBox txtSearchText = (TextBox)Page.Master.FindControl("txtSearchText");
                if (txtSearchText != null)
                {
                    txtSearchText.Text = filterText.ToString();
                }
            }
            litSearchType.Text = searchType;

        }

        private void BindProduct()
        {
            var products = new List<Entity.Product>();
            var filterType = string.Empty;
            var filterText = string.Empty;
            var CatId = "0";
            if (Request.QueryString["SCatId"] != null)
            {
                filterType = "SUBCATEGORY";
                CatId = Request.QueryString["SCatId"].ToString();
                products = ProductManager.FilterProducts(filterType, CatId, "ASC");
            }
            if (Request.QueryString["CatId"] != null)
            {
                filterType = "CATEGORY";
                CatId = Request.QueryString["CatId"].ToString();
                products = ProductManager.FilterProducts(filterType, CatId, "ASC");
            }
            if (Request.QueryString["q"] != null)
            {
                filterType = "SEARCH";
                filterText = Request.QueryString["q"].ToString();
                products = ProductManager.FilterProducts(filterType, filterText, "ASC");
            }
            if (string.IsNullOrEmpty(filterType))
            {
                products = ProductManager.FilterProducts(filterType, CatId, "ASC");
            }
            rptProduct.DataSource = products;
            rptProduct.DataBind();

            litSearchCount.Text = products.Count.ToString();
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