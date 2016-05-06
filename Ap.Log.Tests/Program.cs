using System;
using Ap.Logs.Files;
using Ap.Logs.Message;

namespace Ap.Logs.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Initialize(e => Log.Out.Error("unhandled", e),
               new FileLogger("Logs/Infos", "Info"),
               new FileLogger("Logs/Errors", "Error"));

            Log.Out.Info("Info");
            Log.Out.Error("Error", new Exception("Exception"));
        }
    }
}
