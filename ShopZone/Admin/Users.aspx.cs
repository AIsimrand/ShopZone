using ShopZone.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopZone.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindUsers();
            }
        }

        private void BindUsers()
        {
            Repeater1.DataSource = AccountManager.GetUsers(isActive: null, isDeleted: false);
            Repeater1.DataBind();
        }
       
    }
}