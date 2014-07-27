using Any.Logs.Extentions;

namespace Any.Logs.Test.Case2
{
    public class Program
    {
        public void Test()
        {
            Log.Initialize(new ConsoleErrorBuilder(), new ConsoleLogger());
            Log.Out.Error("Test message");
        }
    }
}
