using Portfolio.EmailService.Services;

namespace Portfolio.EmailService;

public class MockEmailService : IEmailService
{
    public async Task SendEmailAsync(string senderEmail, string subject, string plainTextContent, string htmlContent)
    {
        await Task.Delay(100);
        
        Console.WriteLine("Mock Email Sent:");
        Console.WriteLine($"From: {senderEmail}");
        Console.WriteLine($"To: example@example.com");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Plain Text Content: {plainTextContent}");
        Console.WriteLine($"HTML Content: {htmlContent}");
    }
}
