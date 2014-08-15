using System.Threading.Tasks;

namespace Any.Logs.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        public virtual void Flush() { }

        public virtual bool IsEnabledFor(string method)
        {
            return true;
        }

        public abstract Task WriteAsync(string summary, string description);
    }
}