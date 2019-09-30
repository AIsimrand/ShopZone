using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Net.Mail;
using System.Net;

namespace ShopZone
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "admin@gmail.com";
            // any address where the email will be sending
            var toAddress = txtemail.Text.ToString();
            var toAddress1 = "";
            //Password of your gmail address
            const string fromPassword = "admin";
            // Passing the values and make a email formate to display
            string subject = txtsubject.Text.ToString();
            string body = "From: " + txtname.Text + "\n";
            body += "Email: " + txtemail.Text + "\n";
            body += "Subject: " + txtsubject.Text + "\n";
            body += "Question: \n" + txtcomment.Text + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=RAHUL\SQLSERVER;Initial Catalog=ShopZone;Integrated Security=True");
                con.Open();

                String insertquery = "insert into Contact values('" + txtname.Text + "','" + txtemail.Text + "','" + txtsubject.Text + "','" + txtcomment.Text + "')";


                SqlCommand CMD = new SqlCommand(insertquery, con);
                CMD.ExecuteNonQuery();
                con.Close();
                //lblmsg.Text = "sucess";
                SendMail();
                lblmsg.Text = "Your Comments after sending the mail";
                lblmsg.Visible = true;
                txtsubject.Text = "";
                txtemail.Text = "";
                txtname.Text = "";
                txtcomment.Text = "";







            }

            catch (Exception ex)
            {

            }
        }
    }
}



       