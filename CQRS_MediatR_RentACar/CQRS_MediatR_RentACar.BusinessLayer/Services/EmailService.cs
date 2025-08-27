using CQRS_MediatR_RentACar.BusinessLayer.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_MediatR_RentACar.BusinessLayer.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mimeMessage = new MimeMessage();

            // Gönderen
            var from = new MailboxAddress("RentACar Support", "YOUR_GMAIL_ADDRESS");
            mimeMessage.From.Add(from);

            // Alıcı
            var toAddress = new MailboxAddress("User", to);
            mimeMessage.To.Add(toAddress);

            // Konu ve gövde
            mimeMessage.Subject = subject;
            var bodyBuilder = new BodyBuilder { TextBody = body };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // SMTP Client
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, false);
            await smtpClient.AuthenticateAsync("YOUR_GMAIL_ADDRESS", "YOUR_GOOGLE_KEY");
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
