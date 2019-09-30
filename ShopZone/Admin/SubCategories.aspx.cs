using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class SubCategories : System.Web.UI.Page
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
            int catId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
            var parent = CategoryManager.GetCategory(catId, isActive: null, isDeleted: false);
            lblParentCategory.Text = parent.Name;
            Repeater1.DataSource = CategoryManager.GetSubCategories(catId, isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }

        protected void imgButtonDelete_Click(object sender, EventArgs e)
        {

            int catId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var category = CategoryManager.GetCategory(catId, isActive: null, isDeleted: false);

            if (category != null)
            {
                category.IsDeleted = true;
                CategoryManager.SaveCategory(category);
                Bind();
            }
        }

        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            int parentCatId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
            int catId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Response.Redirect("~/Admin/SaveSubCategory.aspx?CategoryId="+ parentCatId.ToString() +"&Id=" + catId.ToString(), false);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
            Response.Redirect("~/Admin/SaveSubCategory.aspx?CategoryId=" + catId.ToString() + "&Id=-1", false);

        }
    }


}