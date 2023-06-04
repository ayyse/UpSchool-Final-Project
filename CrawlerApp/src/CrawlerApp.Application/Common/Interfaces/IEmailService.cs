using CrawlerApp.Application.Common.Models.Email;

namespace CrawlerApp.Application.Common.Interfaces
{
    public interface IEmailService
    {
        void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto);
    }
}
