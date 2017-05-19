using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyConnectorHandler : AbstractChannelHandlerAdapter<RpcResponse>
    {
        private readonly IMessageHandler _handler;

        public NettyConnectorHandler(IMessageHandler handler, ISerializer serializer) : base(serializer)
        {
            _handler = handler;
        }

        public override void DoChannelRead(IChannelHandlerContext context, RpcResponse message)
        {
            IChannel channel = new NettyChannel(_serializer, context.Channel);

            _handler.ReceiveAsync(message);
        }
    }
}