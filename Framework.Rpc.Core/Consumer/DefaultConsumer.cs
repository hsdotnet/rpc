using System.Threading.Tasks;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;

namespace Framework.Rpc.Core.Consumer
{
    public class DefaultConsumer : AbstractConsumer
    {
        public DefaultConsumer(IMessageHandler handler, ClientCacheContainer cacheContainer, ILoadBalance loadBalance, ISerializer serializer)
            : base(handler, cacheContainer, loadBalance, serializer)
        {

        }

        public override Task DoSend(IChannel channel, RpcRequest request)
        {
            return channel.Write(request);
        }
    }
}