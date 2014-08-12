using System;
using System.Diagnostics;
using Any.Logs.Builders.Extentions;

namespace Any.Logs.Builders
{
    public class EmptyContentBuilder : IContentBuilder
    {
        private static readonly EmptyContentBuilder _instance = new EmptyContentBuilder();

        internal static EmptyContentBuilder Instance
        {
            get { return _instance; }
        }

        public virtual string Summary(string summary)
        {
            return summary;
        }

        public virtual string Description(string description)
        {
            return description;
        }

        public virtual string Description(Exception e)
        {
            return e.GetFullMessage();
        }

        public virtual string Description(StackTrace stackTrace)
        {
            return stackTrace.ToString();
        }
    }
}