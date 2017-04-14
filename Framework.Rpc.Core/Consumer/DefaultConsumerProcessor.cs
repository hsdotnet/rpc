using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;
using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Consumer
{
    public class DefaultConsumerProcessor : IConsumerProcessor
    {
        private readonly ClientCacheContainer _cacheContainer;

        public DefaultConsumerProcessor(ClientCacheContainer cacheContainer)
        {
            _cacheContainer = cacheContainer;
        }

        public void HandleMessage(IChannel channel, RpcResponse response)
        {
            if (_cacheContainer.ResponseBag.ContainsKey(response.RequestId))
            {
                _cacheContainer.ResponseBag[response.RequestId].SetResult(response);
            }
        }
    }
}