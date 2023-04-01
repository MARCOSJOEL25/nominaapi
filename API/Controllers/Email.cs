using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Email : ControllerBase
    {
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("From Name", "from@example.com"));
        emailMessage.To.Add(new MailboxAddress("To Name", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync("your-email@gmail.com", "your-email-password");
        await client.SendAsync(emailMessage);

        await client.DisconnectAsync(true);
    }   
    }
}