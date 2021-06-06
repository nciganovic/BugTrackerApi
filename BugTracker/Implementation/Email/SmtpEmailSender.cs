using Application.Dto;
using Application.Email;
using Application.Settings;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly MailSettings mailSettings;

        public SmtpEmailSender(IOptions<MailSettings> options)
        {
            mailSettings = options.Value;
        }

        public void SendEmail(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailSettings.Mail, mailSettings.Password)
            };

            var message = new MailMessage(mailSettings.Mail, dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Content;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
