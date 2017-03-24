using System;

using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Server
{
    public abstract class AbstractServerHandler : IServerHandler
    {
        protected readonly ServerCacheContainer cacheContainer;

        public AbstractServerHandler(ServerCacheContainer cacheContainer)
        {
            this.cacheContainer = cacheContainer;
        }

        public void HandleException(RpcWrapper rpcWrapper, RpcRequest rpcRequest, Exception ex)
        {
            throw new NotImplementedException();
        }

        public RpcRequest HandleRequest(RpcRequest request)
        {
            
            //foreach (IInterceptor interceptor in server.Interceptors)
            //{
            //    interceptor.BeforeInvoke(rpcWrapper, rpcRequest);
            //}

            //RpcResponse rpcResponse = null;

            //foreach (IInterceptor interceptor in server.Interceptors)
            //{
            //    interceptor.AfterInvoke(rpcWrapper, rpcRequest, rpcResponse);
            //}

            return null;
        }
    }
}