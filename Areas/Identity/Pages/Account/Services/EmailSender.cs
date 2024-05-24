using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HealthNCare.Areas.Identity.Pages.Account.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services; // EmailSettings'ın bulunduğu namespace

namespace HealthNCare.Areas.Identity.Pages.Account.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                    smtpClient.EnableSsl = _emailSettings.EnableSsl;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
                        mailMessage.To.Add(email);
                        mailMessage.Subject = subject;
                        mailMessage.Body = message;
                        mailMessage.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Burada istisna yönetimi yapılabilir veya istisnayı yeniden fırlatılabilir
                throw;
            }
        }
    }
}
