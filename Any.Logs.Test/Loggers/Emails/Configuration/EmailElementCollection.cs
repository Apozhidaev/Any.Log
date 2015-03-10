using System.Configuration;

namespace Any.Logs.Test.Loggers.Emails.Configuration
{
    [ConfigurationCollection(typeof(EmailElement), AddItemName = "logger",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class EmailElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EmailElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EmailElement)element).Methods;
        }
    }
}