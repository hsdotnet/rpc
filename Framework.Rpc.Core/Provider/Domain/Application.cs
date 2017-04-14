using System.Collections.Generic;

using Framework.Rpc.Core.Transport;
using Framework.Rpc.Core.Registry;
using Framework.Rpc.Core.Serializer;

namespace Framework.Rpc.Core.Provider.Domain
{
    public class Application
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public string Cluster { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public long Time { get; set; }

        public TransportType Transport { get; set; }

        public SerializerType Serializer { get; set; }

        /// <summary>
        /// 注册
        /// </summary>
        public RegisterType Register { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisterAddress { get; set; }

        public List<ServiceMetadata> ServiceMetadatas { get; set; }

        public Application()
        {
            ServiceMetadatas = new List<ServiceMetadata>();
        }
    }
}