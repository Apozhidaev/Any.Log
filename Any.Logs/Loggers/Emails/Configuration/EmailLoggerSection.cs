using System.Configuration;

namespace Any.Logs.Loggers.Emails.Configuration
{
    public class EmailLoggerSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty LoggersProperty =
            new ConfigurationProperty(
                "loggers",
                typeof (EmailElementCollection),
                null,
                ConfigurationPropertyOptions.IsRequired);

        public EmailLoggerSection()
        {
            base.Properties.Add(LoggersProperty);
        }

        [ConfigurationProperty("loggers", IsRequired = true)]
        public EmailElementCollection Loggers
        {
            get { return (EmailElementCollection) this[LoggersProperty]; }
        }

        [ConfigurationProperty("host")]
        public string Host
        {
            get { return (string)this["host"]; }
        }

        [ConfigurationProperty("port")]
        public int Port
        {
            get { return (int)this["port"]; }
        }

        [ConfigurationProperty("user")]
        public string User
        {
            get { return (string)this["user"]; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
        }

        [ConfigurationProperty("enableSsl")]
        public bool EnableSsl
        {
            get { return (bool)this["enableSsl"]; }
        }

        [ConfigurationProperty("useDefaultCredentials")]
        public bool UseDefaultCredentials
        {
            get { return (bool)this["useDefaultCredentials"]; }
        }
    }
}