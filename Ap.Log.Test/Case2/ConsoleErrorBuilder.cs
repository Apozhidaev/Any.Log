using System;
using System.Diagnostics;

namespace Ap.Logs.Tests.Case2
{
    public class ConsoleErrorBuilder 
    {
        public string Build(string message, StackTrace stackTrace)
        {
            return String.Format("{0}: {1}", Process.GetCurrentProcess().ProcessName, message);
        }

        public string Build(string message, Exception e)
        {
            return String.Format("{0}{1}{2}", message, Environment.NewLine, e.Message);
        }

        public string Summary(string summary)
        {
            throw new NotImplementedException();
        }

        public string Description(StackTrace stackTrace)
        {
            throw new NotImplementedException();
        }

        public string Description(Exception e)
        {
            throw new NotImplementedException();
        }
    }
}