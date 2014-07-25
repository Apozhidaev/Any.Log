using System;
using Any.Logs.Extentions;

namespace Any.Logs.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Out.InitializeDefault(new ConsoleLogger());
            Log.Out.Error("Test message");
            Console.ReadKey();
        }
    }
}
