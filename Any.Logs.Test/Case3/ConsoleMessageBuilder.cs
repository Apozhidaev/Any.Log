using System;

namespace Any.Logs.Test.Case3
{
    public class ConsoleMessageBuilder
    {
        public string Build(int userId, string message)
        {
            return String.Format("{0}: {1}", userId, message);
        }
    }
}