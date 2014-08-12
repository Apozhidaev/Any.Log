namespace Any.Logs.Test.Case3
{
    public class Program
    {
        public void Test()
        {
            Log.Initialize(new ConsoleMessageBuilder(), new ConsoleLogger());
            //Log.Out.Message(777 ,"Test message");
        }
    }
}
