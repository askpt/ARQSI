using IDEIBiblio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace IDEIBiblio.EmailNotifications
{
    public class EmailNotifications
    {
        #region const values
        protected static SmtpClient CreateSmtpClient()
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("idei.biblio2013@gmail.com", "antasaarder2013") //please don't hack my account, you'll ruin my business!!
            };
            return client;
        }

        // Specify the e-mail sender.
        // Create a mailing address that includes a UTF8 character
        // in the display name.
        private static MailAddress _from = new MailAddress("idei.biblio2013@gmail.com", "IDEIBiblio no reply", System.Text.Encoding.UTF8);
        #endregion

        public static void SendEmailBecauseRegister(string toEmail, string userName)
        {
            SmtpClient client = CreateSmtpClient();

            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(toEmail);
            // Specify the message content.
            MailMessage message = new MailMessage(_from, to);

            message.Body = "User ID: " + userName;
            message.Body += "Email: " + toEmail;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "IDEIBiblio Register";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            // method to identify this send operation.
            client.Send(message);
        }

        public static void SendEmailBecauseOrder(string toEmail, int orderID, float totalPrice, IList<Book> books, IList<Magazine> magazines)
        {
            SmtpClient client = CreateSmtpClient();

            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(toEmail);
            // Specify the message content.
            MailMessage message = new MailMessage(_from, to);

            message.Body = "Order ID: " + orderID;
            message.Body += "\nTotal Price: " + totalPrice;
            if (books.Count > 0)
            {
                message.Body += "\n-- Books --";
                foreach (var item in books)
                {
                    message.Body += "\n" + item.Title;
                }
            }

            if (magazines.Count > 0)
            {
                message.Body += "\n-- Magazines --";
                foreach (var item in magazines)
                {
                    message.Body += "\n" + item.Title;
                }
            }

            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "IDEIBiblio Order";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            // method to identify this send operation.
            client.Send(message);
        }
    }
}