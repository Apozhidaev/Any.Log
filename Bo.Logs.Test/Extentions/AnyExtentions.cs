using System;
using System.Diagnostics;
using System.Text;

namespace Any.Logs.Test.Extentions
{
    public static class AnyExtentions
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

        public static string Format(this string str, object[] values)
        {
            return values.Length > 0 ? String.Format(str, values) : str;
        }
    }
}