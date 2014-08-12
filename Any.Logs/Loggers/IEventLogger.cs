using System.Threading.Tasks;

namespace Any.Logs.Loggers
{
    public interface IEventLogger : ILogger
    {
        Task WriteAsync(string summary, string description);
    }
}