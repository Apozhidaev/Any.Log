using System;
using System.Threading.Tasks;
using Any.Logs.Builders;
using Any.Logs.Loggers;

namespace Any.Logs.Extentions
{
    public static class LogExtensions
    {
        public static Task Error(this Log log, string message, params object[] values)
        {
            IErrorBuilder builder = log.ContentBuilder as IErrorBuilder ?? ErrorBuilder.Instance;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(String.Format(message, values))));
        }

        public static Task Error(this Log log, Exception e, string message, params object[] values)
        {
            IErrorBuilder builder = log.ContentBuilder as IErrorBuilder ?? ErrorBuilder.Instance;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(String.Format(message, values), e)));
        }
    }
}