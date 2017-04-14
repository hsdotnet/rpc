using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyAcceptorHandler : AbstractChannelHandlerAdapter<RpcRequest>
    {
        private readonly IProviderProcessor _processor;

        public NettyAcceptorHandler(IProviderProcessor processor, ISerializer serializer) : base(serializer)
        {
            _processor = processor;
        }

        public override void DoChannelRead(IChannelHandlerContext context, RpcRequest message)
        {
            IChannel channel = new NettyChannel(_serializer, context.Channel);

            _processor.HandleMessage(channel, message);
        }
    }
}