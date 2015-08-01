using System.Configuration;

namespace Ap.Logs.Tests.Loggers.Files.Configuration
{
    public class FileLoggerSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty LoggersProperty =
            new ConfigurationProperty(
                "loggers",
                typeof (FileElementCollection),
                null,
                ConfigurationPropertyOptions.IsRequired);

        public FileLoggerSection()
        {
            base.Properties.Add(LoggersProperty);
        }

        [ConfigurationProperty("loggers", IsRequired = true)]
        public FileElementCollection Loggers
        {
            get { return (FileElementCollection) this[LoggersProperty]; }
        }
    }
}