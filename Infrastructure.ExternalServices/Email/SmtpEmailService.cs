using System.Net;
using System.Net.Mail;
using Application.Services.Interfaces;
using Infrastructure.ExternalServices.Email.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.ExternalServices.Email;

public class SmtpEmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly SmtpClientOptions _smtpSettings;

    public SmtpEmailService(IOptions<SmtpClientOptions> smtpOptions)
    {
        _smtpSettings = smtpOptions.Value;
        _smtpClient = new SmtpClient
        {
            Host = _smtpSettings.Host,
            Port = _smtpSettings.Port,
            EnableSsl = _smtpSettings.EnableSsl,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
        };
    }

    public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
    {
        var mailMessage = new MailMessage()
        {
            From = new MailAddress(_smtpSettings.Username),
            Subject = subject,
            Body = body,
            IsBodyHtml = isHtml,
        };

        mailMessage.To.Add(to);

        await _smtpClient.SendMailAsync(mailMessage);
        _smtpClient.Dispose();
    }
}