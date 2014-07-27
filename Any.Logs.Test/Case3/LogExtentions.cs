using System;
using System.Threading.Tasks;
using Any.Logs.Loggers;

namespace Any.Logs.Test.Case3
{
    public static class LogExtentions
    {
        public static Task Message(this Log log, int userId, string message, params object[] values)
        {
            var builder = (ConsoleMessageBuilder)log.ContentBuilder;
            return log.WriteAsync<IMessageLogger>(logger => logger.WriteAsync(builder.Build(userId, String.Format(message, values))));
        }
    }
}