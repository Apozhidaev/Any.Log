using System.Threading.Tasks;

namespace Any.Logs.Loggers
{
    public interface IMessageLogger : ILogger
    {
        Task WriteAsync(string message);
    }
}