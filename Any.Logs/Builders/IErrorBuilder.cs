using System;

namespace Any.Logs.Builders
{
    public interface IErrorBuilder
    {
        string Build(string message);
        string Build(string message, Exception e);
    }
}