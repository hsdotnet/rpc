using System;
using System.Net;

using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyConnector : AbstractNettyConnector
    {
        private readonly IConsumerProcessor _processor;

        private readonly ISerializer _serializer;

        public NettyConnector(IConsumerProcessor processor, ISerializer serializer)
        {
            _processor = processor;

            _serializer = serializer;

            Init();
        }

        protected override IChannel DoConnect(string host, int port)
        {
            bootstrap.Handler(new ActionChannelInitializer<TcpSocketChannel>((tcpSocketChannel) =>
               {
                   IChannelPipeline pipeline = tcpSocketChannel.Pipeline;
                   pipeline.AddLast(new NettyConnectorHandler(_processor, _serializer));
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
            bootstrap.Option(ChannelOption.SoReuseaddr, true);
            bootstrap.Option(ChannelOption.SoKeepalive, true);
        }

        protected override void DoProcessor(IProviderProcessor processor)
        {
            throw new NotImplementedException();
        }
    }
}