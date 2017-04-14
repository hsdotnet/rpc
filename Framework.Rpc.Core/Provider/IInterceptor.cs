using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Provider
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public interface IInterceptor
    {
        void BeforeInvoke(RpcWrapper rpcWrapper, RpcRequest rpcRequest);

        void AfterInvoke(RpcWrapper rpcWrapper, RpcRequest rpcRequest, RpcResponse rpcResponse);
    }
}