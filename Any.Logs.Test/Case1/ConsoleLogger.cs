using System;
using System.Threading.Tasks;
using Any.Logs.Loggers;

namespace Any.Logs.Test.Case1
{
    public class ConsoleLogger : LoggerBase
    {
        public void Flush() { }

        public bool IsEnabledFor(string methodName)
        {
            return true;
        }

        public override Task WriteAsync(string summary, string description)
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync(string message)
        {
            return Task.Run(() => Console.WriteLine(message));
        }
    }
}