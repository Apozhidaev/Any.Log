using System.Configuration;

namespace Ap.Logs.Tests.Loggers.Emails.Configuration
{
    public class EmailElement : ConfigurationElement
    {
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

        [ConfigurationProperty("subject")]
        public string Subject
        {
            get { return (string)this["subject"]; }
        }

        [ConfigurationProperty("period", IsRequired = true, DefaultValue = 1)]
        [IntegerValidator(MinValue = 1, MaxValue = 1440)]
        public int Period
        {
            get { return (int)this["period"]; }
        }

        [ConfigurationProperty("methods")]
        public string Methods
        {
            get { return (string)this["methods"]; }
        }
    }
}