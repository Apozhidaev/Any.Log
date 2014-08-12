using System;
using System.Diagnostics;

namespace Any.Logs.Builders
{
    public interface IContentBuilder
    {
        string Summary(string summary);
        string Description(string description);
        string Description(Exception e);
        string Description(StackTrace stackTrace);
    }
}