using System.Configuration;

namespace Any.Logs.Loggers.Files.Configuration
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