using System;
using System.Diagnostics;
using Any.Logs.Builders;
using Any.Logs.Loggers;

namespace Any.Logs.Extentions
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            var builder = log.ContentBuilder as IContentBuilder ?? EmptyContentBuilder.Instance;
            var buildSummary = builder.Summary(Format(summary, values));
            var buildDescription = builder.Description(stackTrace);
            log.WriteAsync<IEventLogger>(logger => logger.WriteAsync(buildSummary, buildDescription));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            var builder = log.ContentBuilder as IContentBuilder ?? EmptyContentBuilder.Instance;
            var buildSummary = builder.Summary(Format(summary, values));
            var buildDescription = builder.Description(e);
            log.WriteAsync<IEventLogger>(logger => logger.WriteAsync(buildSummary, buildDescription));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            var builder = log.ContentBuilder as IContentBuilder ?? EmptyContentBuilder.Instance;
            var buildSummary = builder.Summary(Format(summary, values));
            var buildDescription = builder.Description(String.Empty);
            log.WriteAsync<IEventLogger>(logger => logger.WriteAsync(buildSummary, buildDescription));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            var builder = log.ContentBuilder as IContentBuilder ?? EmptyContentBuilder.Instance;
            var buildSummary = builder.Summary(Format(summary, values));
            var buildDescription = builder.Description(description);
            log.WriteAsync<IEventLogger>(logger => logger.WriteAsync(buildSummary, buildDescription));
        }

        private static string Format(string message, object[] values)
        {
            return values.Length > 0 ? String.Format(message, values) : message;
        }
    }
}