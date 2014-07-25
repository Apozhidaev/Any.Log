using System;
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
    }
}