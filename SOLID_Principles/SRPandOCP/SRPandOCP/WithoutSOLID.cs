using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SRPandOCP
{
    public class WithoutSOLID
    {
        public void MailSend(string to, string subject, string body)
        {
            
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("otomasyondenememail@gmail.com");
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;    //25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new NetworkCredential("otomasyondenememail@gmail.com", "tqxvlygcleosbvxv");
            smtp.Send(mail);
            
        }
    }
}
