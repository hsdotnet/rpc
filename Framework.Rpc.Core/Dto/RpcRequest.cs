using System;

namespace Framework.Rpc.Core.Dto
{
    [Serializable]
    public class RpcRequest
    {
        public string AppName { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string GroupName { get; set; }

        public string RequestId { get; set; }

        /// <summary>
        /// 服务名称 ClassName
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 方法参数
        /// </summary>
        public object[] Parameters { get; set; }

        public RpcRequest()
        {
            RequestId = Guid.NewGuid().ToString();
        }

        public RpcRequest(string serviceName, string methodName)
            : this()
        {
            ServiceName = serviceName;
            MethodName = methodName;
        }
    }
}