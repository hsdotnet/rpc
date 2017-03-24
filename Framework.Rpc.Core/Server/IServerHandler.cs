using System;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Server
{
    public interface IServerHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rpcWrapper"></param>
        /// <param name="rpcRequest"></param>
        RpcResponse HandleRequest(RpcRequest rpcRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rpcWrapper"></param>
        /// <param name="rpcRequest"></param>
        /// <param name="ex"></param>
        //void HandleException(RpcWrapper rpcWrapper, RpcRequest rpcRequest, Exception ex);
    }
}