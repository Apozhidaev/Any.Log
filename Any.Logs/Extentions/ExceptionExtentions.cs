using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Any.Logs.Builders.Extentions
{
    public static class ExceptionExtentions
    {
        public static string GetFullMessage(this Exception exception)
        {
            var fullMessage = new StringBuilder();
            var aggr = exception as AggregateException;
            if (aggr != null)
            {
                foreach (Exception innerException in aggr.InnerExceptions)
                {
                    fullMessage.Append(innerException.GetFullMessage());
                }
            }
            else
            {
                while (exception != null)
                {
                    fullMessage.Append(String.Format("{2}---{0}---{2}{1}{2}", exception.Message, exception.StackTrace,
                        Environment.NewLine));
                    exception = exception.InnerException;
                }
            }
            return fullMessage.ToString();
        }

        public static string GetCallerMethodName(this StackTrace stackTrace)
        {
            return stackTrace.GetFrame(0).GetMethod().Name;
        }
    }
}