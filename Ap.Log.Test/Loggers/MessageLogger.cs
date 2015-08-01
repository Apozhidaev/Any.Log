using System.Threading.Tasks;

namespace Ap.Logs.Tests.Loggers
{
    public abstract class MessageLogger : ILogger
    {
        public virtual void Flush() { }

        public virtual bool IsEnabledFor(string method)
        {
            return true;
        }

        public abstract Task WriteAsync(string message);
    }
}