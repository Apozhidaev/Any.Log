using Any.Logs.Loggers;

namespace Any.Logs.Test.Case2
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
