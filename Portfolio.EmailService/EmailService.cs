using Azure.Communication.Email;

using Portfolio.EmailService.Exceptions;
using Portfolio.EmailService.Services;

namespace Portfolio.EmailService
{
    public class EmailService : IEmailService
    {
        private EmailClient _client;
        private EmailAddress _recipientEmailAddress;

        public EmailService(string connectionString, string recipientEmailAddress) 
        { 
            _client = new EmailClient(connectionString);
            _recipientEmailAddress = new EmailAddress(recipientEmailAddress);
        }

        public async Task SendEmailAsync(string senderEmail, string subject, string plainTextContent, string htmlContent)
        {
            try
            {
                var recipientList = new List<EmailAddress> { _recipientEmailAddress };
                var recipients = new EmailRecipients(recipientList);
                
                var content = new EmailContent(subject);
                content.Html = htmlContent;
                content.PlainText = plainTextContent;

                var emailMessage = new EmailMessage(senderEmail, recipients, content);

                var response = await _client.SendAsync(Azure.WaitUntil.Completed, emailMessage);

                if (response.Value.Status == EmailSendStatus.Succeeded)
                    Console.WriteLine($"Email sent successfully");
                else
                    throw new EmailServiceException($"Failed to send email, status: {response.Value.Status}");
            }
            catch (Exception ex)
            {
                throw new EmailServiceException($"Exception while sending email: {ex.Message}");
            }
        }
    }
}
