using Framework.Rpc.Core.Protocol;
using Framework.Rpc.Core.Registry;
using Framework.Rpc.Core.Serializer;

namespace Framework.Rpc.Core.Dto
{
    public class RpcApplication
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public string Cluster { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public long Time { get; set; }

        public ProtocolType Protocol { get; set; }

        public SerializerType Serializer { get; set; }

        /// <summary>
        /// 注册
        /// </summary>
        public RegisterType Register { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        public string RegisterAddress { get; set; }
    }
}
