using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Any.Logs.Builders;
using Any.Logs.Builders.Extentions;
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
            Initialize(null, loggers);
        }

        public static void Initialize(object contentBuilder, params ILogger[] loggers)
        {
            _out = new Log(contentBuilder, loggers);
        }


        private readonly object _contentBuilder;

        private readonly LoggerManager _loggerManager;

        protected Log(object contentBuilder, params ILogger[] loggers)
        {
            if (loggers == null || loggers.Length == 0)
            {
                throw new ArgumentException("loggers");
            }

            _contentBuilder = contentBuilder;
            _loggerManager = new LoggerManager(loggers);

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        public object ContentBuilder
        {
            get { return _contentBuilder; }
        }
        public Task WriteAsync<T>(Func<T, Task> writer) where T : ILogger
        {
            var stackTrace = new StackTrace(1);
            return _loggerManager.WriteAsync(stackTrace.GetCallerMethodName(), writer);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception) e.ExceptionObject;
            var builder = ContentBuilder as IContentBuilder ?? EmptyContentBuilder.Instance;
            WriteAsync<IEventLogger>(logger => logger.WriteAsync(builder.Summary("Unhandled exception"), builder.Description(exception)))
                .ContinueWith(_ => _loggerManager.Flush());
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            _loggerManager.Flush();
        }
    }
}