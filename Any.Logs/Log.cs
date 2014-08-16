using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Any.Logs.Extentions;
using Any.Logs.Loggers;

namespace Any.Logs
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
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        public Task WriteAsync<T>(Func<T, Task> writer) where T : ILogger
        {
            var method = new StackTrace(1).GetCallerMethodName();
            return _loggerManager.WriteAsync(method, writer);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            const string method = "Error";
            var exception = (Exception)e.ExceptionObject;
            _loggerManager.WriteAsync<MessageLogger>(method,
                logger => logger.WriteAsync(String.Format("{1}{0}{2}", Environment.NewLine, "Unhandled exception", exception.GetFullMessage())))
                    .ContinueWith(_ => _loggerManager.Flush()).Wait();
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _loggerManager.Flush();
        }
    }
}