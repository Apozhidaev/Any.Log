using System;
using System.Diagnostics;
using Any.Logs.Builders.Extentions;

namespace Any.Logs.Builders
{
    public class DefaultContentBuilder : EmptyContentBuilder
    {
        public override string Summary(string summary)
        {
            var methodName = new StackTrace(1).GetCallerMethodName();
            return String.Format("[{1}] - {2}{0}{3}", Environment.NewLine, methodName, DateTime.Now, summary);
        }
    }
}