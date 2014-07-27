using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Any.Logs.Loggers.Emails;
using Any.Logs.Loggers.Emails.Configuration;
using Any.Logs.Loggers.Files;
using Any.Logs.Loggers.Files.Configuration;

namespace Any.Logs.Loggers
{
    public static class LogExtensions
    {
        public static void InitializeDefault(this Log log, params ILogger[] loggers)
        {
            log.InitializeDefault(null, loggers);
        }

        public static void InitializeDefault(this Log log, object contentBuilder, params ILogger[] loggers)
        {
            var loggerList = new List<ILogger>(loggers);

            var fileConfig = ConfigurationManager.GetSection("anylog/file") as FileLoggerSection;
            if (fileConfig != null)
            {
                loggerList.AddRange(fileConfig.Loggers.OfType<FileElement>().Select(loggerConfig => new FileLogger(loggerConfig)));
            }

            var emailConfig = ConfigurationManager.GetSection("anylog/email") as EmailLoggerSection;
            if (emailConfig != null)
            {
                loggerList.AddRange(emailConfig.Loggers.OfType<EmailElement>().Select(loggerConfig => new EmailLogger(loggerConfig, emailConfig)));
            }

            Log.Initialize(contentBuilder, loggerList.ToArray());
        }
    }
}