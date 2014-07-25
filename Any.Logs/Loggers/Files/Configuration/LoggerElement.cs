using System.Configuration;

namespace Ubs.Common.Loggers.Configuration
{
    public class LoggerElement : ConfigurationElement
    {
        [ConfigurationProperty("useLogger")]
        public bool UseLogger
        {
            get { return (bool)this["useLogger"]; }
        }
    }
}