using System.Threading;

using System.Collections.Concurrent;

namespace Framework.Rpc.Core.Dto
{
    /// <summary>
    /// 一次RPC请求发送与返回数据包定义
    /// </summary>
    public class RpcWrapper
    {
        /// <summary>
        /// 类型 协议字段
        /// </summary>
        public RpcWrapperType WrapperType { get; set; }

        /// <summary>
        /// 请求线程ID，用于包回调通知  协议字段
        /// </summary>
        public long ThreadId { get; set; }

        /// <summary>
        /// 请求线程类seq，用于标记请求发送 协议字段
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// data数据结构长度  协议字段
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 请求body  协议字段,RpcRequest 序列化后存储
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// 请求发送方，用于网络传递
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 请求发送方，用于网络传递
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 请求上下文参数加入传递
        /// </summary>
        public ConcurrentDictionary<string, object> RpcContext { get; set; }

        public RpcWrapper()
        {

        }

        public RpcWrapper(RpcWrapperType wrapperType, int index, int length, byte[] data)
        {
            WrapperType = wrapperType;
            Index = index;
            Length = length;
            Data = data;
            ThreadId = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
