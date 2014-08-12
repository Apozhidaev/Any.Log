using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Any.Logs.Loggers.Emails.Configuration;

namespace Any.Logs.Loggers.Emails
{
    internal class EmailLogger : IEventLogger
    {
        private readonly EmailElement _config;

        private readonly EmailService _emailService;
        private readonly StringBuilder _message = new StringBuilder();
        private readonly HashSet<string> _methods = new HashSet<string>();

        public EmailLogger(EmailElement config, EmailLoggerSection emailConfig)
        {
            _config = config;
            _emailService = new EmailService(emailConfig);
            if (!String.IsNullOrEmpty(_config.Methods))
            {
                foreach (string method in _config.Methods.Split(',').Select(m => m.Trim()))
                {
                    _methods.Add(method);
                }
            }

            var timer = new Timer(_ => DoSend());
            timer.Change(1000, _config.Period*60*1000);
            if (!String.IsNullOrEmpty(_config.Methods))
            {
                foreach (string method in _config.Methods.Split(',').Select(m => m.Trim()))
                {
                    _methods.Add(method);
                }
            }
        }

        public bool IsEnabledFor(string methodName)
        {
            return _methods.Count == 0 || _methods.Contains(methodName);
        }

        public Task WriteAsync(string summary, string description)
        {
            return Task.Factory.StartNew(() =>
            {
                lock (_message)
                {
                    _message.Append(summary.Replace(Environment.NewLine, "<br>"));
                    _message.Append("<br>");
                    _message.Append(description.Replace(Environment.NewLine, "<br>"));
                    _message.Append("<br>===================================================<br>");
                }
            });
        }

        public void Flush()
        {
            DoSend();
        }

        private void DoSend()
        {
            string message;
            lock (_message)
            {
                if (_message.Length == 0)
                {
                    return;
                }
                message = _message.ToString();
                _message.Clear();
            }

            _emailService.Send(new EmailModel
            {
                Subject = _config.Subject,
                From = _config.From,
                To = _config.To,
                Body = message
            });
        }
    }
}