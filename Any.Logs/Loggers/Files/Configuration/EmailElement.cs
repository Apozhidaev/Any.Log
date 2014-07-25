using System.Configuration;

namespace Ubs.Common.Loggers.Configuration
{
    public class EmailElement : LoggerElement
    {
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

        [ConfigurationProperty("from")]
        public string From
        {
            get { return (string)this["from"]; }
        }

        [ConfigurationProperty("to")]
        public string To
        {
            get { return (string)this["to"]; }
        }
    }
}