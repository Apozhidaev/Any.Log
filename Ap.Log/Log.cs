using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Ap.Logs
{
    public class Log
    {
        private static Action<Exception> _unhandler;
        public static Log Out { get; private set; }

        public static void Initialize(params ILogger[] loggers)
        {
            Out = new Log(loggers);
        }

        public static void Initialize(Action<Exception> unhandler, params ILogger[] loggers)
        {
            _unhandler = unhandler;
            Initialize(loggers);
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

        public Task WriteAsync<T>(Func<T, Task> writer, [CallerMemberName]string method = "") where T : ILogger
        {
            return _loggerManager.WriteAsync(method, writer);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _unhandler?.Invoke(e.ExceptionObject as Exception);
            OnProcessExit(sender, e);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _loggerManager.Flush();
        }
    }
}