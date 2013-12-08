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
        public static void SendEmail(string toEmail, int orderID, float totalPrice, IList<Book> books, IList<Magazine> magazines)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential() //without credentials for safety purposes
            };

            // Specify the e-mail sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("andres.silva010@gmail.com", "André Silva", System.Text.Encoding.UTF8);
            // Set destinations for the e-mail message.
            MailAddress to = new MailAddress(toEmail);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);

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