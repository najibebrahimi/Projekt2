using Azure.Communication.Email;
using Microsoft.AspNetCore.Mvc;
using Portfolio.EmailService.Exceptions;
using Portfolio.EmailService.Services;
using Portfolio.RESTAPI.Models;


namespace Portfolio.RESTAPI.Controllers;

[ApiController]
[Route("api/forms")]
public class ContactController : ControllerBase
{
    private readonly IEmailService _emailService;

    public ContactController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("contact")]
    public async Task<IActionResult> SendContactEmail([FromBody] ContactFormModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Message))
        {
            return BadRequest(new { error = "All fields are required." });
        }

        try
        {
            var senderEmail = model.Email;
            var subject = $"New Contact Form Submission from {model.Name}";
            var htmlContent = model.Message;

            try
            {
                await _emailService.SendEmailAsync(senderEmail, subject, htmlContent, htmlContent);
                return Ok(new { message = "Email sent successfully!" });
            }
            catch (EmailServiceException ex)
            {
                return StatusCode(500, new { error = $"Failed to send the email - {ex.Message}" });
            }   
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error sending email: {ex.Message}");
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }
}
