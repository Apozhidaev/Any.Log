using System;
using System.Diagnostics;
using Any.Logs.Loggers;

namespace Any.Logs.Extentions
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, Format(summary, values), stackTrace.ToString())));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, Format(summary, values), e.GetFullMessage())));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(Format(summary, values)));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            log.WriteAsync<MessageLogger>(logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, Format(summary, values), description)));
        }

        private static string Format(string message, object[] values)
        {
            return values.Length > 0 ? String.Format(message, values) : message;
        }
    }
}