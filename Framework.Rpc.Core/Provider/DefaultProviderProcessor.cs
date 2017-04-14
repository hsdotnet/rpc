using System;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Provider.Domain;
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

            ServiceMetadata serviceMetadata = _cacheContainer.Application.ServiceMetadatas.Find(m => m.ServiceName == request.ServiceName);

            if (serviceMetadata == null)
            {

            }

            object service = Activator.CreateInstance(serviceMetadata.ServiceImplType);

            MethodMetadata methodMetadata = serviceMetadata.MethodMetadatas.Find(m => m.MethodName == request.MethodName);

            if (methodMetadata == null)
            {

            }

            response.Result = methodMetadata.Method.Invoke(service, request.Parameters);

            channel.Write(response);
        }
    }
}