using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CleanArquitecture.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; set; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(Application.Models.Email email)
        {
            SendGridClient client = new SendGridClient(_emailSettings.ApiKey);

            string subject = email.Subject;
            EmailAddress to = new EmailAddress(email.To);
            string emailBody = email.Body;

            EmailAddress from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from,to,subject,emailBody,emailBody);
            Response response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK) return true;

            _logger.LogError("El email no pudo enviarse, existen errores");
            return false;
        }
    }
}
