using System;
using System.Threading.Tasks;

namespace Ap.Logs.Message
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, Exception e)
        {
            log.WriteAsync<MessageLoggerBase>(logger => logger.WriteAsync($"{summary}{Environment.NewLine}{e.GetMessage()}"));
        }

        public static Task Info(this Log log, string summary)
        {
            return log.WriteAsync<MessageLoggerBase>(logger => logger.WriteAsync(summary));
        }
    }
}