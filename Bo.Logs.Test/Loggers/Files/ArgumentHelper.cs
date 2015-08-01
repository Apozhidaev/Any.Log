using System;
using System.Collections.Generic;
using System.Linq;

namespace Any.Logs.Test.Loggers.Files
{
    internal static class ArgumentHelper
    {
        public static Dictionary<string, string> Parse()
        {
            string[] args = Environment.GetCommandLineArgs();
            return args.Select(item => item.Split('='))
                .Where(keyValue => keyValue.Length == 2)
                .ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);
        }
    }
}