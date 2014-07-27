using System;
using Any.Logs.Extentions;

namespace Any.Logs.Test.Case1
{
    public class Program
    {
        public void Test()
        {
            Log.Initialize(new ConsoleLogger());
            Log.Out.Error("Test message");
            
        }
    }
}
