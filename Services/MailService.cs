using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

using System.Text;
using System.Net.Mime;

namespace stafix24.pl.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {

            try
            {
            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress("jacek.rawiak@hotmail.com", "Administrator witryny STAFix24.pl"));

            // From
            mailMsg.From = new MailAddress("noreply@stafix24.pl", "Witryna STAFix24.pl");

            // Subject and multipart/alternative Body
            mailMsg.Subject = subject;
            string text = body;
            string html = @"<p>"+body+"</p>";
            //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("azure_0668b4ea696ee6ff57032277a9e79919@azure.com", "mgbo5wtl");
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
            }
            catch (Exception)
            {
            return false;
            }

            return true;

        }
    }
}