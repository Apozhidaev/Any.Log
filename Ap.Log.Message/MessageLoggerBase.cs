using System.Threading.Tasks;

namespace Ap.Logs.Message
{
    public abstract class MessageLoggerBase : LoggerBase
    {
        public abstract Task WriteAsync(string message);
    }
}