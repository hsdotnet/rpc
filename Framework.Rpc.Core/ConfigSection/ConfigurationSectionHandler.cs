using System.Configuration;
using System.Xml;

namespace Framework.Rpc.Core.ConfigSection
{
    public class ConfigurationSectionHandler<T> : IConfigurationSectionHandler
    {
        private static T settings;

        public static T Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = (T)ConfigurationManager.GetSection(typeof(T).Name);
                }

                return settings;
            }
        }

        public object Create(object parent, object configContext, XmlNode section)
        {
            return ConfigHelper.Deserialize<T>(section.OuterXml);
        }
    }
}