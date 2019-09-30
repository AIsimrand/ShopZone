using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ShopZone.Helper
{
    public class EmailHelper
    {
        public static KeyValuePair<bool, string> SendMail(string toList, string from, string ccList, string subject, string body)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            var result = new KeyValuePair<bool, string>(false, "");
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (ccList != null && ccList != string.Empty)
                    message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("ShopzoneTest@gmail.com", "Shopzone123");

                smtpClient.Send(message);
                result = new KeyValuePair<bool,string>(true, "Mail Sent");
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                result = new KeyValuePair<bool, string>(true, msg);
            }
            return result;
        }
    }
}