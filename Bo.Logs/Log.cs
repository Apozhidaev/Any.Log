using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bo.Logs
{
    public class Log
    {
        private static Log _out;

        public static Log Out
        {
            get { return _out; }
        }

        public static void Initialize(params ILogger[] loggers)
        {
            _out = new Log(loggers);
        }

        private readonly LoggerManager _loggerManager;

        protected Log(params ILogger[] loggers)
        {
            if (loggers == null || loggers.Length == 0)
            {
                throw new ArgumentException("loggers");
            }

            _loggerManager = new LoggerManager(loggers);

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            AppDomain.CurrentDomain.UnhandledException += OnProcessExit;
        }

        public Task WriteAsync<T>(Func<T, Task> writer) where T : ILogger
        {
            var stackTrace = new StackTrace(1);
            var method =  stackTrace.GetFrame(0).GetMethod().Name;;
            return _loggerManager.WriteAsync(method, writer);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _loggerManager.Flush();
        }
    }
}