using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Registry;
using Framework.Rpc.Core.Protocol;

namespace Framework.Rpc.Core.ConfigSection
{
    public class BaseSection
    {
        /// <summary>
        /// 协议配置 默认Netty
        /// </summary>
        public ProtocolType Protocol { get; set; }

        /// <summary>
        /// 序列化类型
        /// </summary>
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
