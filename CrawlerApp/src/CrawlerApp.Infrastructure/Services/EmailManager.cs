using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Application.Common.Models.Email;
using System.Net;
using System.Net.Mail;

namespace CrawlerApp.Infrastructure.Services
{
    public class EmailManager : IEmailService
    {
        public void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto)
        {
            var htmlContent = $"<h4>Hi, {sendEmailConfirmationDto.Name}</h4> </br> <p>your email activation {sendEmailConfirmationDto.Link}</p>";
            
            var subject = $"Confirm your Email Address";

            Send(new SendEmailDto(sendEmailConfirmationDto.Email, htmlContent, subject));
        }

        private void Send(SendEmailDto sendEmailDto)
        {
            MailMessage message = new MailMessage();

            sendEmailDto.EmailAddresses.ForEach(emailAddress => message.To.Add(emailAddress));

            message.From = new MailAddress("noreply@entegraturk.com");

            message.Subject = sendEmailDto.Subject;

            message.IsBodyHtml = true;

            message.Body = sendEmailDto.Content;

            SmtpClient client = new SmtpClient();

            client.Port = 587;

            client.Host = "mail.entegraturk.com";

            client.EnableSsl = false;

            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential("noreply@entegraturk.com", "xzx2xg4Jttrbzm5nIJ2kj1pE4l");

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(message);
        }
    }
}
