using System;
using System.Diagnostics;
using Any.Logs.Builders.Extentions;

namespace Any.Logs.Builders
{
    public class ErrorBuilder : IErrorBuilder
    {
        private static readonly ErrorBuilder _instance = new ErrorBuilder();

        internal static ErrorBuilder Instance
        {
            get { return _instance; }
        }

        public string Build(string message, StackTrace stackTrace)
        {
            return String.Format("[Error] - {1}{0}{2}{0}{3}", Environment.NewLine, DateTime.Now, message, stackTrace);
        }

        public string Build(string message, Exception e)
        {
            return String.Format("[Error] - {1}{0}{2}{0}{3}", Environment.NewLine, DateTime.Now, message, e.GetFullMessage());
        }
    }
}