using System;
using System.Diagnostics;
using Ap.Logs.Tests.Extentions;

namespace Ap.Logs.Tests.Loggers.Extentions
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            var message = String.Format("[Error] - {1}{0}{2}{0}{3}", Environment.NewLine, DateTime.Now, summary.Format(values),  new StackTrace(1));
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(message));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            var message = String.Format("[Error] - {1}{0}{2}{0}{3}", Environment.NewLine, DateTime.Now, summary.Format(values), e.GetFullMessage());
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(message));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            var message = String.Format("[Info] - {1}{0}{2}", Environment.NewLine, DateTime.Now, summary.Format(values));
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(message));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            var message = String.Format("[Info] - {1}{0}{2}{0}{3}", Environment.NewLine, DateTime.Now, summary.Format(values), description);
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(message));
        }
    }
}