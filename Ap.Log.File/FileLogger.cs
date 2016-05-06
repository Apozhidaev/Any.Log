using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ap.Logs.Message;

namespace Ap.Logs.Files
{
    public class FileLogger : MessageLoggerBase
    {
        private readonly string _root;
        private readonly HashSet<string> _methods;
        private static readonly object FileLoker = new object();

        public FileLogger(string root, params string[] methods)
        {
            _root = root ?? string.Empty;
            if (_root != string.Empty && !Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }
            if (methods.Length > 0)
            {
                _methods = new HashSet<string>(methods);
            }
        }

        public override bool IsEnabledFor(string method)
        {
            return _methods == null || _methods.Contains(method);
        }

        public override Task WriteAsync(string message)
        {
            return Task.Run(() => Append(message));
        }

        private void Append(string message)
        {
            lock (FileLoker)
            {
                var path = Path.Combine(_root, $"log-{DateTime.Now.ToString("yyyy.MM.dd")}.txt");
                File.AppendAllText(path, string.Format("{0}{1}{0}==================================================={0}", Environment.NewLine, message));
            }
        }
    }
}