using System.Configuration;

namespace Any.Logs.Test.Loggers.Files.Configuration
{
    [ConfigurationCollection(typeof(FileElement), AddItemName = "logger",
        CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class FileElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FileElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FileElement)element).Methods;
        }
    }
}