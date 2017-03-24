using System.Net;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Dto;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels.Sockets;

namespace Framework.Rpc.Core.Protocol.Netty.Client
{
    public class NettyAcceptor : IAcceptor
    {
        private readonly ClientCacheContainer clientCacheContainer;

        private readonly ISerializer serializer;

        private readonly ClientReferenceServer referenceServer;

        public NettyAcceptor(ClientReferenceServer referenceServer, ClientCacheContainer clientCacheContainer, ISerializer serializer)
        {
            this.clientCacheContainer = clientCacheContainer;

            this.serializer = serializer;

            this.referenceServer = referenceServer;
        }

        private void Connect()
        {
            IEventLoopGroup group = new MultithreadEventLoopGroup();

            Bootstrap bootstrap = new Bootstrap();

            bootstrap.Group(group).Channel<TcpSocketChannel>()
                .Handler(new ActionChannelInitializer<TcpSocketChannel>((tcpSocketChannel) =>
                {
                    IChannelPipeline pipeline = tcpSocketChannel.Pipeline;
                    pipeline.AddLast(new NettyAcceptorHandler(clientCacheContainer, serializer));
                }))
                .Option(ChannelOption.TcpNodelay, true)
                .Option(ChannelOption.SoReuseaddr, true)
                .Option(ChannelOption.SoKeepalive, true);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(referenceServer.Host), referenceServer.Port);
            bootstrap.RemoteAddress(endPoint);

            IChannel channel = bootstrap.ConnectAsync().Result;

            referenceServer.Connection = channel;

            clientCacheContainer.ClientReferenceServers.Add(referenceServer);
        }

        public void Start()
        {
            Connect();
        }

        public void Stop()
        {

        }
    }
}