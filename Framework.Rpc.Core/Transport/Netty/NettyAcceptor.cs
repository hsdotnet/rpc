using System.Net;

using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyAcceptor : AbstractNettyAcceptor
    {
        private readonly IProviderProcessor _processor;

        private readonly ISerializer _serializer;

        public NettyAcceptor(IProviderProcessor processor, ISerializer serializer)
        {
            _processor = processor;

            _serializer = serializer;

            Init();
        }

        protected override IChannel DoBind(string host, int port)
        {
            bootstrap.ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
            {
                IChannelPipeline pipeline = channel.Pipeline;
                pipeline.AddLast(new NettyAcceptorHandler(_processor, _serializer));
            }));

            IPEndPoint point = new IPEndPoint(IPAddress.Parse(host), port);

            var task = bootstrap.BindAsync(point);

            return new NettyChannel(_serializer, task.Result);
        }

        protected override void DoInit()
        {
            bootstrap.Channel<TcpServerSocketChannel>();

            bootstrap.Option(ChannelOption.SoBacklog, 1024);
        }
    }
}
