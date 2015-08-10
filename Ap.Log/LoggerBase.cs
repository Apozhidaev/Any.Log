namespace Ap.Logs
{
    public abstract class LoggerBase : ILogger
    {
        public virtual void Flush() { }

        public virtual bool IsEnabledFor(string method) { return true; }
    }
}