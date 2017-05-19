using System;
using System.Net;

using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyConnector : AbstractNettyConnector
    {
        private readonly IMessageHandler _handler;

        private readonly ISerializer _serializer;

        public NettyConnector(IMessageHandler handler, ISerializer serializer)
        {
            _handler = handler;

            _serializer = serializer;

            Init();
        }

        protected override IChannel DoConnect(string host, int port)
        {
            bootstrap.Handler(new ActionChannelInitializer<TcpSocketChannel>((tcpSocketChannel) =>
               {
                   IChannelPipeline pipeline = tcpSocketChannel.Pipeline;
                   pipeline.AddLast(new NettyConnectorHandler(_handler, _serializer));
               }));

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(host), port);
            bootstrap.RemoteAddress(endPoint);

            var channel = bootstrap.ConnectAsync().Result;

            return new NettyChannel(_serializer, channel);
        }

        protected override void DoInit()
        {
            bootstrap.Channel<TcpSocketChannel>();

            bootstrap.Option(ChannelOption.TcpNodelay, true);
            bootstrap.Option(ChannelOption.ConnectTimeout, TimeSpan.FromSeconds(3));
        }

        protected override void DoProcessor(IProviderProcessor processor)
        {
            throw new NotImplementedException();
        }
    }
}