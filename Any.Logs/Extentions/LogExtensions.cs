using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Any.Logs.Builders;
using Any.Logs.Loggers;

namespace Any.Logs.Extentions
{
    public static class LogExtensions
    {
        public static Task Error(this Log log, string message, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            IErrorBuilder builder = log.ContentBuilder as IErrorBuilder ?? ErrorBuilder.Instance;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(Format(message, values), stackTrace)));
        }

        public static Task Error(this Log log, Exception e, string message, params object[] values)
        {
            IErrorBuilder builder = log.ContentBuilder as IErrorBuilder ?? ErrorBuilder.Instance;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(Format(message, values), e)));
        }

        public static Task Info(this Log log, string message, params object[] values)
        {
            var stackTrace = new StackTrace(1);
            IInfoBuilder builder = log.ContentBuilder as IInfoBuilder ?? InfoBuilder.Instance;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(Format(message, values), stackTrace)));
        }

        private static string Format(string message, object[] values)
        {
            return values.Length > 0 ? String.Format(message, values) : message;
        }
    }
}