using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ap.Logs.Message;
using EmailSender;

namespace Ap.Logs.Email
{
    public class EmailLogger : MessageLoggerBase
    {
        private readonly LoggerSettings _settings;

        private readonly SmtpService _emailService;
        private readonly StringBuilder _message = new StringBuilder();
        private readonly HashSet<string> _methods;

        public EmailLogger(LoggerSettings settings, SmtpSettings smtpSettings)
        {
            _settings = settings;
            _emailService = new SmtpService(smtpSettings);
            if (settings.Methods?.Length > 0)
            {
                _methods = new HashSet<string>(settings.Methods);
            }

            var timer = new Timer(_ => DoSend());
            timer.Change(1000, _settings.Period * 60 * 1000);
        }

        public override bool IsEnabledFor(string method)
        {
            return _methods == null || _methods.Contains(method);
        }

        public override Task WriteAsync(string message)
        {
            return Task.Run(() =>
            {
                lock (_message)
                {
                    _message.Append(message.Replace(Environment.NewLine, "<br>"));
                    _message.Append("<br>===================================================<br>");
                }
            });
        }

        public override void Flush()
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
            _emailService.Send(_settings.Recipients, _settings.Subject, message);
        }
    }
}