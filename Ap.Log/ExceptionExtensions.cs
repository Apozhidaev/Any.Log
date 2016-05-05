using System;

namespace Ap.Logs
{
    public static class ExceptionExtensions
    {
        public static string GetMessage(this Exception e)
        {
            var eBase = e.GetBaseException();
            return string.Format("{1}: {2}{0}StackTrace:{0}{3}", Environment.NewLine, eBase.GetType().Name, eBase.Message, eBase.StackTrace);
        }
    }
}