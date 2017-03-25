using System;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Server;

namespace Framework.Rpc.Core.Protocol.Netty.Server
{
    public class NettyServerHandler : AbstractServerHandler
    {
        public NettyServerHandler(ServerCacheContainer serverCacheContainer) :
            base(serverCacheContainer)
        {
        }

        public override RpcResponse DoHandleRequest(RpcRequest request)
        {
            RpcResponse response = new RpcResponse() { RequestId = request.RequestId };

            RpcServiceMetadata serviceMetadata = serverCacheContainer.ServiceMetadatas[request.ServiceName];

            object service = Activator.CreateInstance(serviceMetadata.ServiceImplType);

            var method = serviceMetadata.ServiceImplType.GetMethod(request.MethodName);

            response.Result = method.Invoke(service, request.Parameters);

            return response;
        }
    }
}