using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyConnectorHandler : AbstractChannelHandlerAdapter<RpcResponse>
    {
        private readonly IConsumerProcessor _processor;

        public NettyConnectorHandler(IConsumerProcessor processor, ISerializer serializer) : base(serializer)
        {
            _processor = processor;
        }

        public override void DoChannelRead(IChannelHandlerContext context, RpcResponse message)
        {
            IChannel channel = new NettyChannel(_serializer, context.Channel);

            _processor.HandleMessage(channel, message);
        }
    }
}