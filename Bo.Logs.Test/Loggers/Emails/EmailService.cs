using System.Net;
using System.Net.Mail;
using Any.Logs.Test.Loggers.Emails.Configuration;

namespace Any.Logs.Test.Loggers.Emails
{
    internal class EmailService
    {
        private readonly EmailLoggerSection _config;

        public EmailService(EmailLoggerSection config)
        {
            _config = config;
        }

        public void Send(EmailModel email)
        {
            var smtp = new SmtpClient
            {
                Host = _config.Host,
                Port = _config.Port,
                EnableSsl = _config.EnableSsl,
                UseDefaultCredentials = _config.UseDefaultCredentials
            };

            if (!smtp.UseDefaultCredentials)
            {
                smtp.Credentials = new NetworkCredential(_config.User, _config.Password);
            }

            var mail = new MailMessage
            {
                From = new MailAddress(email.From),
                Subject = email.Subject,
                IsBodyHtml = true,
                Body = email.Body
            };

            string[] recipients = email.To.Split(',', ';');

            foreach (string to in recipients)
            {
                mail.To.Add(new MailAddress(to));
            }

            if (email.Attachmets != null)
            {
                foreach (string fileName in email.Attachmets)
                {
                    var attachment = new Attachment(fileName);
                    mail.Attachments.Add(attachment);
                }
            }

            smtp.Send(mail);
        }
    }
}