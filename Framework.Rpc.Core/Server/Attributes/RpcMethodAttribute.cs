using System;

namespace Framework.Rpc.Core.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RpcMethodAttribute : Attribute
    {
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; private set; }

        public RpcMethodAttribute(string methodName) : this(methodName, string.Empty)
        {

        }

        public RpcMethodAttribute(string methodName, string description)
        {
            MethodName = methodName;
            Description = description;
        }
    }
}