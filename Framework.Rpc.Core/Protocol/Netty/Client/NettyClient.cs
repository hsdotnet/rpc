using Framework.Rpc.Core.Client;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Container;

using DotNetty.Transport.Channels;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using DotNetty.Codecs;

namespace Framework.Rpc.Core.Protocol.Netty.Client
{
    public class NettyClient : AbstractClient
    {
        public NettyClient(ClientCacheContainer clientCacheContainer, ILoadBalance loadBalance, ISerializer serializer)
            : base(clientCacheContainer, loadBalance, serializer)
        {
        }

        public override RpcResponse DoSend(RpcRequest request, ClientReferenceServer referenceServer)
        {
            IChannel channel = (IChannel)referenceServer.Connection;

            var data = NettyByteBufferHelper.GetByteBuffer(serializer, request);

            channel.WriteAndFlushAsync(data).Wait();

            return null;
        }

        public override void SetAcceptor(ClientReferenceServer referenceServer)
        {
            Acceptor = new NettyAcceptor(referenceServer, clientCacheContainer, serializer);
        }
    }
}