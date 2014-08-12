using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Any.Logs.Loggers.Files.Configuration;

namespace Any.Logs.Loggers.Files
{
    internal class FileLogger : IEventLogger
    {
        private readonly HashSet<string> _methods = new HashSet<string>();
        private readonly Mutex _mutex;

        private readonly string _path;

        public FileLogger(FileElement config)
        {
            if (!String.IsNullOrEmpty(config.Methods))
            {
                foreach (string method in config.Methods.Split(',').Select(m => m.Trim()))
                {
                    _methods.Add(method);
                }
            }

            string path = config.Path;
            if (path.Contains(Patterns.Root))
            {
                Dictionary<string, string> arguments = ArgumentHelper.Parse();
                if (arguments.ContainsKey(Arguments.Root))
                {
                    path = path.Replace(Patterns.Root, arguments[Arguments.Root]);
                }
            }
            if (path.Contains(Patterns.CurrentDirectory))
            {
                path = path.Replace(Patterns.CurrentDirectory, Environment.CurrentDirectory);
            }
            _path = path.TrimEnd('\\');
            if (!String.IsNullOrWhiteSpace(_path) && !Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            string mutexName = String.Format("Any_mutex_for_exclusive_file_access-{0}",
                _path.Replace(":", "_").Replace("\\", "_"));
            _mutex = new Mutex(false, mutexName);
        }

        public bool IsEnabledFor(string methodName)
        {
            return _methods.Count == 0 || _methods.Contains(methodName);
        }

        public Task WriteAsync(string summary, string description)
        {
            return Task.Factory.StartNew(() => AddToFile(summary, description));
        }

        public virtual void Flush()
        {
        }

        private void AddToFile(string summary, string description)
        {
            try
            {
                _mutex.WaitOne();
                File.AppendAllText(String.Format("{0}\\log-{1}.txt", _path, DateTime.Now.ToString(Formats.SortedDate)),
                    String.Format("{0}{1}{0}{2}{0}==================================================={1}", Environment.NewLine,
                        summary, description));
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}