using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Any.Logs.Builders.Extentions;

namespace Any.Logs
{
    internal class LoggerManager
    {
        private readonly ILogger[] _loggers;

        private readonly LinkedList<Task> _waitingList = new LinkedList<Task>();

        public LoggerManager(ILogger[] loggers)
        {
            _loggers = loggers;
        }

        public Task WriteAsync<T>(string method, Func<T, Task> writer) where T : ILogger
        {
            Task task = Task.Factory.StartNew(() => Task.WaitAll(
                _loggers.OfType<T>()
                    .Where(logger => logger.IsEnabledFor(method))
                    .Select(writer).ToArray()));

            lock (_waitingList)
            {
                _waitingList.AddLast(task);
            }

            return task.ContinueWith(_ =>
            {
                lock (_waitingList)
                {
                    _waitingList.Remove(task);
                }
            });
        }

        public void Flush()
        {
            Task[] waitingTasks;
            lock (_waitingList)
            {
                waitingTasks = _waitingList.ToArray();
            }
            try
            {
                Task.WaitAll(waitingTasks);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.GetFullMessage());
                Debug.Fail("LoggerManager.Flush exception");
            }
            foreach (ILogger logger in _loggers)
            {
                logger.Flush();
            }
        }
    }
}