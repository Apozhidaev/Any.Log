using System.Configuration;

namespace Ubs.Common.Loggers.Configuration
{
    public class FileElement : LoggerElement
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
        }
    }
}