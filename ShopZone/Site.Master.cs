using ShopZone.Entity;
using ShopZone.Helper;
using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Model = ShopZone.Entity;

namespace ShopZone
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCategories();
                BindUserDetails();
            }
            litSubscribe.Text = "";

            litCartItemCount.Text = CartHelper.CurrentCart.Count().ToString();
        }
        protected void hlnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx", false);
        }
        private void BindUserDetails()
        {
            bool isLoginUser = (HttpContext.Current.User.Identity.IsAuthenticated && Session["UserInfo"] != null);

            divWelcome.Visible = isLoginUser;
            ulLogin.Visible = !isLoginUser;
            if (isLoginUser)
            {
                var currentUser = (LoginUser)Session["UserInfo"];
                litUsername.Text = currentUser.EmailId;
            }
          
        }

        private void BindCategories()
        {

            var categories = CategoryManager.GetCategories(true, false);
            rptLeftMenu.DataSource = categories.Take(10).ToList();
            rptLeftMenu.DataBind();

            rptFooterCategories.DataSource = categories;
            rptFooterCategories.DataBind();

            rptTopBrands.DataSource = categories.Where(i => i.IsTopBrand == true)
                .OrderByDescending(i => i.LastUpdatedOn)
                .OrderByDescending(i => i.CreatedOn)
                .Take(10).ToList();
            rptTopBrands.DataBind();

            var products = ProductManager.GetProducts(true, false).Where(i => i.IsFeaturedProduct == true)
                .OrderByDescending(i => i.LastUpdatedOn)
                .OrderByDescending(i => i.CreatedOn)
                .Take(10).ToList();
            rptFeaturedProduct.DataSource = products;
            rptFeaturedProduct.DataBind();

        }

        protected void rptLeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlImage imgNestedArrow = (HtmlImage)e.Item.FindControl("imgNestedArrow");
                imgNestedArrow.Visible = false;
                Model.Category cateoryItem = (Model.Category)e.Item.DataItem;
                if (cateoryItem.SubCategories.Any())
                {
                    Repeater rpt = (Repeater)e.Item.FindControl("rptLMSubCategories");
                    if (rpt != null && cateoryItem.SubCategories != null && cateoryItem.SubCategories.Any())
                    {
                        rpt.DataSource = cateoryItem.SubCategories;
                        rpt.DataBind();

                        imgNestedArrow.Visible = true;
                    }
                    else
                    {
                        rpt.Visible = false;
                    }
                }
            }

        }

        protected void btnSubScribe_Click(object sender, EventArgs e)
        {
            var span = (HtmlControl)this.FindControl("spnNewsletterMsg");
            try
            {
                var result = AccountManager.SubscribeNewsletter(txtSubscribeEmailId.Text);

                litSubscribe.Text = "You have successfully subscribed to our newsletter.";


                span.Attributes.Remove("class");

                span.Attributes.Add("class", "success");

            }
            catch (ArgumentException ex)
            {
                litSubscribe.Text = ex.Message;

                span.Attributes.Remove("class");

                span.Attributes.Add("class", "fail");
            }
            catch (Exception ex)
            {

                litSubscribe.Text = ex.Message;

                span.Attributes.Remove("class");

                span.Attributes.Add("class", "fail");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Product.aspx?q=" + txtSearchText.Text.Trim(), false);
        }
    }
}