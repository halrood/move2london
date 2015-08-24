using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MoveToLondon.Models
{
    public class EmailHelper
    {
        public static void SendEmail(string SentByEmailAddress, string Password, string SendToEmailAddress, string EmailBody, string SMTPHostAddress, string EmailSubject = "", string SendersTitleName = "", bool AllowHTML = true)
        {
            MailMessage msgMail = new MailMessage();

            MailMessage myMessage = new MailMessage();
            myMessage.From = new MailAddress(SentByEmailAddress, SendersTitleName);
            myMessage.To.Add(SendToEmailAddress);
            myMessage.Subject = EmailSubject;
            myMessage.IsBodyHtml = AllowHTML;

            myMessage.Body = EmailBody;

            SmtpClient mySmtpClient = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(SentByEmailAddress, Password);
            mySmtpClient.Host = SMTPHostAddress;
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = myCredential;
            mySmtpClient.ServicePoint.MaxIdleTime = 1;

            mySmtpClient.Send(myMessage);
            myMessage.Dispose();
        }
    }
}
