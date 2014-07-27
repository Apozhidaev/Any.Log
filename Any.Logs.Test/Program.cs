using System;

namespace Any.Logs.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            new Case1.Program().Test();
            new Case2.Program().Test();
            new Case3.Program().Test();

            Console.ReadKey();
        }
    }
}
