namespace Ap.Logs
{
    public abstract class LoggerBase : ILogger
    {
        public void Flush() { }

        public bool IsEnabledFor(string method) { return true; }
    }
}