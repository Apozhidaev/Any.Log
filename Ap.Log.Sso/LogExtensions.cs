using System;
using System.Threading.Tasks;

namespace Ap.Logs.Sso
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string token, string summary, Exception e)
        {
            log.WriteAsync<SsoLogger>(logger => logger.WriteAsync(token, 1, $"{summary}{Environment.NewLine}{e.GetMessage()}"));
        }

        public static Task Info(this Log log, string token, string summary)
        {
            return log.WriteAsync<SsoLogger>(logger => logger.WriteAsync(token, 2, summary));
        }
    }
}