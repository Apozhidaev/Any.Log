using System.Configuration;

namespace Ap.Logs.Tests.Loggers.Files.Configuration
{
    public class FileElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
        }

        [ConfigurationProperty("methods")]
        public string Methods
        {
            get { return (string)this["methods"]; }
        }
    }
}