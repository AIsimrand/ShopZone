using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ShopZone.Entity;

using Model = ShopZone.Entity;
using System.Configuration;
using ShopZone.Manager;
namespace ShopZone
{
    public partial class FeedBack : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeaterData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          

            var feedBack = new Model.Feedback
            {
                Name = txtName.Text,
                Subject = txtSubject.Text,
                Message = txtComment.Text,
                CreatedOn = DateTime.Now,

            };
            FeedbackManager. Save(feedBack);
            txtName.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtComment.Text = string.Empty;



            BindRepeaterData();

        }

        protected void BindRepeaterData()
        {


            var feedbacks = FeedbackManager.Get();
            if (feedbacks.Any())
            {
                RepDetails.Visible = true;
                RepDetails.DataSource = feedbacks;
                RepDetails.DataBind();
            }
            else
            {
                RepDetails.Visible = false;
            }

        }
    }
}