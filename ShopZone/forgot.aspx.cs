using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ShopZone
{
    public partial class forgot : System.Web.UI.Page
    {
        
                
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                SqlConnection con = new SqlConnection(entity.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand("select SecurityQuestion from LoginUser where EmailId='" + txtemailid.Text + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Label2.Visible = true;
                    Label3.Visible = true;
                    Button5.Visible = true;
                    txtSecurityquestion.Visible = true;
                    txtsecurityanswer.Visible = true;
                    txtSecurityquestion.Text = dr.GetString(0);
                    Label6.Text = "";
                }
                else
                {
                    Label6.Text = "No such Email id Registered";
                }
                con.Close();
            }

            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                SqlConnection con = new SqlConnection(entity.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand("select SecurityAnswer from LoginUser where  EmailId='" + txtemailid.Text + "' ", con);
                con.Open();
                string a;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    a = dr.GetString(0);
                    if (a.Equals(txtsecurityanswer.Text))
                    {
                        Label7.Text = "";
                        Label4.Visible = true;
                        Label5.Visible = true;
                        Button3.Visible = true;
                        txtpassword.Visible = true;
                        txtretypepassword.Visible = true;
                    }
                    else
                    {
                        Label7.Text = "Wrong Answer";
                    }

                }
                con.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                SqlConnection con = new SqlConnection(entity.Connection.ConnectionString);

                SqlCommand cmd = new SqlCommand("update LoginUser set Password='" + txtpassword.Text + "' where EmailId='" + txtemailid.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("Index.aspx");
        }
    }
}