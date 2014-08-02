using System;
using System.Diagnostics;
using Any.Logs.Builders.Extentions;

namespace Any.Logs.Builders
{
    public class InfoBuilder : IInfoBuilder
    {
        private static readonly InfoBuilder _instance = new InfoBuilder();

        internal static InfoBuilder Instance
        {
            get { return _instance; }
        }

        public string Build(string message, StackTrace stackTrace)
        {
            return String.Format("[Info] - {1} ({2}){0}{3}", Environment.NewLine, DateTime.Now, stackTrace.GetCallerMethodName(), message);
        }
    }
}