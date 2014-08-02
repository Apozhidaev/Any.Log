using System.Diagnostics;

namespace Any.Logs.Builders
{
    public interface IInfoBuilder
    {
        string Build(string message, StackTrace stackTrace); 
    }
}