using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmail(object sender, EventArgs e)
        {
            string to = txtTo.Text.Trim(); /*"jonayedrahman26@gmail.com"; //To address */   
            string from = "jonayedrahman26@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            message.Subject = txtSubject.Text.Trim();
            message.Body = txtBody.Text.Trim();
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("jonayedrahman26@gmail.com", "Bijoy8216");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email sent.');", true);
                txtTo.Text = "";
                txtBody.Text = "";
                txtSubject.Text = "";

                lblSend.Visible = true;
                lblSend.Text = "D.O.M.E";
            }

            catch (Exception ex)
            {
                throw ex;
            }
            //SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            //using (MailMessage mm = new MailMessage(smtpSection.From, txtTo.Text.Trim()))
            //{
            //    mm.Subject = txtSubject.Text.Trim();
            //    mm.Body = txtBody.Text.Trim();
            //    mm.IsBodyHtml = false;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = smtpSection.Network.Host;
            //    smtp.EnableSsl = smtpSection.Network.EnableSsl;
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = false;
            //    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
            //    smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
            //    smtp.Credentials = networkCred;
            //    smtp.Port = smtpSection.Network.Port;
            //    smtp.Send(mm);
            //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email sent.');", true);
            //}
        }
    }
}