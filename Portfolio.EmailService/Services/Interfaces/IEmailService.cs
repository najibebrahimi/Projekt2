using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.EmailService.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string senderEmail, string subject, string plainTextContent, string htmlContent);
    }
}
