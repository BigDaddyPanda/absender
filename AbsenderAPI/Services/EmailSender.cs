using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AbsenderAPI.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private SmtpClient client;
        private bool initialized;
        private void InitializeConnexion()
        {

            client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("tekupabsender@gmail.com", "@Absender123");
            initialized = true;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            if (!initialized) InitializeConnexion();
            try
            {

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("tekupabsender@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = message;
                client.Send(mailMessage);

            }
            catch
            {
                Console.WriteLine("CC");
            }
            return Task.CompletedTask;
        }
    }
}
