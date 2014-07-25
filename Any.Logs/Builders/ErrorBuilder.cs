using System;
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

        public string Build(string message)
        {
            return message;
        }

        public string Build(string message, Exception e)
        {
            return String.Format("{0}{1}{2}", message, Environment.NewLine, e.GetFullMessage());
        }
    }
}