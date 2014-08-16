using System;
using System.Diagnostics;
using Any.Logs.Extentions;

namespace Any.Logs.Loggers.Extentions
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, summary.Format(values), stackTrace.ToString())));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, summary.Format(values), e.GetFullMessage())));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(summary.Format(values)));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, summary.Format(values), description)));
        }
    }
}