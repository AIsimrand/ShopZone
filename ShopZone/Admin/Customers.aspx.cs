using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Customers : System.Web.UI.Page
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
            Repeater1.DataSource = AccountManager.GetUsers(isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }
        protected void imgButtonDelete_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            //var category = AccountManager.GetUser(id, isActive: null, isDeleted: false);

            //if (category != null)
            //{
            //    category.IsDeleted = true;
            //    CategoryManager.SaveCategory(category);
            //    Bind();
            //}
        }

        protected void imgBtnEdit_Click(object sender, EventArgs e)
        {
            //int catId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            //Response.Redirect("~/Admin/SaveCategory.aspx?Id=" + catId.ToString(), false);

        }
    }
}