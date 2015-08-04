namespace Ap.Logs
{
    public interface ILogger
    {
        void Flush();

        bool IsEnabledFor(string method);
    }
}