using System;
using System.Diagnostics;

namespace Any.Logs.Builders
{
    public interface IErrorBuilder
    {
        string Build(string message, StackTrace stackTrace);
        string Build(string message, Exception e);
    }
}