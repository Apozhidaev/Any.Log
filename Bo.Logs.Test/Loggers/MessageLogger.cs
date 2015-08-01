﻿using System.Threading.Tasks;
using Bo.Logs;

namespace Any.Logs.Test.Loggers
{
    public abstract class MessageLogger : ILogger
    {
        public virtual void Flush() { }

        public virtual bool IsEnabledFor(string method)
        {
            return true;
        }

        public abstract Task WriteAsync(string message);
    }
}