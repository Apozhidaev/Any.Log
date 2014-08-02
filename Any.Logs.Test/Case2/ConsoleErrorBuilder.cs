using System;
using System.Diagnostics;
using Any.Logs.Builders;

namespace Any.Logs.Test.Case2
{
    public class ConsoleErrorBuilder : IErrorBuilder
    {
        public string Build(string message, StackTrace stackTrace)
        {
            return String.Format("{0}: {1}", Process.GetCurrentProcess().ProcessName, message);
        }

        public string Build(string message, Exception e)
        {
            return String.Format("{0}{1}{2}", message, Environment.NewLine, e.Message);
        }
    }
}