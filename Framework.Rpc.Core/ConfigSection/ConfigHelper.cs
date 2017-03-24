using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Framework.Rpc.Core.ConfigSection
{
    public class ConfigHelper
    {
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(xml)), Encoding.UTF8))
            {
                return (T)xmlSerializer.Deserialize(sr);
            }
        }

        public static T GetSection<T>()
        {
            T section = ConfigurationSectionHandler<T>.Settings;

            if (section == null)
            {
                throw new ArgumentNullException(typeof(T).Name + "未设置");
            }

            return section;
        }
    }
}