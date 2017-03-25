using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Server
{
    public abstract class AbstractServerHandler : IServerHandler
    {
        protected readonly ServerCacheContainer serverCacheContainer;

        public AbstractServerHandler(ServerCacheContainer serverCacheContainer)
        {
            this.serverCacheContainer = serverCacheContainer;
        }

        public RpcResponse HandleRequest(RpcRequest request)
        {
            //foreach (IInterceptor interceptor in server.Interceptors)
            //{
            //    interceptor.BeforeInvoke(rpcWrapper, rpcRequest);
            //}

            RpcResponse response = DoHandleRequest(request);

            //foreach (IInterceptor interceptor in server.Interceptors)
            //{
            //    interceptor.AfterInvoke(rpcWrapper, rpcRequest, rpcResponse);
            //}

            return response;
        }

        public abstract RpcResponse DoHandleRequest(RpcRequest request);
    }
}