using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Any.Logs.Builders.Extentions;
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

            Log.Initialize(loggerList.ToArray());
        }

        public static void Error(this Log log, string summary, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            log.WriteAsync<LoggerBase>(logger => logger.WriteAsync(Format(summary, values), stackTrace.ToString()));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            log.WriteAsync<LoggerBase>(logger => logger.WriteAsync(Format(summary, values), e.GetFullMessage()));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            log.WriteAsync<LoggerBase>(logger => logger.WriteAsync(Format(summary, values), String.Empty));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            log.WriteAsync<LoggerBase>(logger => logger.WriteAsync(Format(summary, values), description));
        }

        private static string Format(string message, object[] values)
        {
            return values.Length > 0 ? String.Format(message, values) : message;
        }
    }
}