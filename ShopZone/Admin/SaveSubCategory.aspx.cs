using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class SaveSubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"].ToString());

                BindCategories();
                if (id > 0)
                {
                    BindSubCategoriesDetails(id);
                }
            }
        }

        private void BindSubCategoriesDetails(int id)
        {

            var cat = CategoryManager.GetCategory(id, isActive: null, isDeleted: false);
            if (cat != null)
            {
                txtName.Text = cat.Name;
                txtDescription.Text = cat.Description;

                chkIsActive.Checked = cat.IsActive;

                if (ddlCategory.Items.FindByValue(cat.ParentId.ToString()) != null)
                {

                    ddlCategory.Items.FindByValue(cat.ParentId.ToString()).Selected = true;
                }
            }
        }

        private void BindCategories()
        {
            int catId = Convert.ToInt32(Request.QueryString["CategoryId"].ToString());
            
            var categories = CategoryManager.GetCategories(isActive: true, isDeleted: false);
            if (categories != null)
            {
                ddlCategory.DataSource = categories;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataBind();
                if (ddlCategory.Items.FindByValue(catId.ToString()) != null)
                {

                    ddlCategory.Items.FindByValue(catId.ToString()).Selected = true;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            var cat = new Category();
            if (id > 0)
            {
                cat = CategoryManager.GetCategory(id, isActive: null, isDeleted: false);

            }

            cat.Name = txtName.Text;
            cat.Description = txtDescription.Text;
            cat.ParentId = Convert.ToInt32(ddlCategory.SelectedValue);

            cat.IsActive = chkIsActive.Checked;

            CategoryManager.SaveCategory(cat);

            Response.Redirect("~/Admin/SubCategories.aspx?CategoryId=" + cat.ParentId.ToString(), false);
        }
    }
}