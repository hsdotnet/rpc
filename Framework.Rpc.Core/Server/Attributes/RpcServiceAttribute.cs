using System;

namespace Framework.Rpc.Core.Server.Attributes
{
    /// <summary>
    /// RpcService
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class RpcServiceAttribute : Attribute
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// 所属组
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; private set; }

        public RpcServiceAttribute(string serviceName, string version)
            : this(serviceName, version, string.Empty, string.Empty)
        {

        }

        public RpcServiceAttribute(string serviceName, string version, string groupName)
            : this(serviceName, version, groupName, string.Empty)
        {

        }

        public RpcServiceAttribute(string serviceName, string version, string groupName, string description)
        {
            ServiceName = serviceName;
            Version = version;
            Description = description;
            GroupName = groupName;
        }
    }
}