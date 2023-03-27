using System.Net.Mail;
using System.Net;

namespace SRPandOCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tWelcome to Mail Sender Service");

            Console.Write("\nPlease Enter The Mail:");
            string mailAddress = Console.ReadLine();

            Console.Write("\nPlease Enter The Subject:");
            string mailSubject = Console.ReadLine();

            Console.Write("\nEnter Your Message:");
            string message = Console.ReadLine();


            MailSender mailSender = new MailSender();
            mailSender.Send(mailAddress, mailSubject, message);

            //WithoutSOLID withoutSOLID = new WithoutSOLID();
            //withoutSOLID.MailSend(mailAddress,mailSubject,message);
        }
    }

    class MailSender
    {
        public void Send(string to, string body, string subject)
        {
            IMailServer mailServer = null;


            if (to.EndsWith("@gmail.com"))
            {
                mailServer = new Gmail();
            }
            else if (to.EndsWith("@hotmail.com"))
            {
                mailServer = new Hotmail();
            }
            else if (to.EndsWith("@yandex.com"))
            {
                mailServer = new Yandex();
            }
            else
            {
                Console.WriteLine("Invalid Mail Address");
                return;
            }

            mailServer.Send(to, body, subject);
        }

    }

    class SmtpMailServer
    {
        public void SmtpService(string from, string to, string password, string subject, string body, string serviceName)
        {
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient($"smtp.{serviceName}.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, password);
            smtpClient.Send(mailMessage);
        }
    }

    interface IMailServer
    {
        void Send(string to, string body, string subject);

    }

    class Gmail : IMailServer
    {
        public void Send(string to, string body, string subject)
        {
            string from = "otomasyondenememail@gmail.com";
            string password = "tqxvlygcleosbvxv";

            SmtpMailServer smtpMailServer = new SmtpMailServer();
            smtpMailServer.SmtpService(from, to, password, subject, body, "gmail");


        }
    }
    class Hotmail : IMailServer
    {
        public void Send(string to, string body, string subject)
        {
            string from = "your_email@hotmail.com";
            string password = "your_password";

            SmtpMailServer smtpMailServer = new SmtpMailServer();
            smtpMailServer.SmtpService(from, to, password, subject, body, "live");
        }
    }
    class Yandex : IMailServer
    {
        public void Send(string to, string body, string subject)
        {
            string from = "your_email@yandex.com";
            string password = "your_password";

            SmtpMailServer smtpMailServer = new SmtpMailServer();
            smtpMailServer.SmtpService(from, to, password, subject, body, "yandex");
        }
    }

    class WithoutSOLID
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
