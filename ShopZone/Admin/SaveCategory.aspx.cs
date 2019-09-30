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
    public partial class SaveCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"].ToString());

                if (id > 0)
                {
                    BindCategoriesDetails(id);
                }
            }
        }


        private void BindCategoriesDetails(int id)
        {
            var cat = CategoryManager.GetCategory(id, isActive: null, isDeleted: false);
            if (cat != null)
            {
                txtName.Text = cat.Name;
                txtDescription.Text = cat.Description;
                chkIsTopBrand.Checked = cat.IsTopBrand;
                chkIsActive.Checked = cat.IsActive;


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
            cat.IsTopBrand = chkIsTopBrand.Checked;
            cat.IsActive = chkIsActive.Checked;

            CategoryManager.SaveCategory(cat);

            Response.Redirect("~/Admin/Categories.aspx", false);
        }
    }
}