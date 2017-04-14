using System;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;

namespace Framework.Rpc.Core.Provider
{
    public class DefaultProviderProcessor : IProviderProcessor
    {
        private readonly ServerCacheContainer _cacheContainer;

        public DefaultProviderProcessor(ServerCacheContainer cacheContainer)
        {
            _cacheContainer = cacheContainer;
        }

        public void HandleMessage(IChannel channel, RpcRequest request)
        {
            RpcResponse response = new RpcResponse() { RequestId = request.RequestId };

            RpcServiceMetadata serviceMetadata = _cacheContainer.ServiceMetadatas[request.ServiceName];

            object service = Activator.CreateInstance(serviceMetadata.ServiceImplType);

            var method = serviceMetadata.ServiceImplType.GetMethod(request.MethodName);

            response.Result = method.Invoke(service, request.Parameters);

            channel.Write(response);
        }
    }
}