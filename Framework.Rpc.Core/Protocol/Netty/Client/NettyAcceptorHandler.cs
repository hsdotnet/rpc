using System;

using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Container;

using DotNetty.Transport.Channels;
using DotNetty.Buffers;

namespace Framework.Rpc.Core.Protocol.Netty.Client
{
    public class NettyAcceptorHandler : ChannelHandlerAdapter
    {
        private readonly ClientCacheContainer clientCacheContainer;

        private readonly ISerializer serializer;

        public NettyAcceptorHandler(ClientCacheContainer clientCacheContainer, ISerializer serializer)
        {
            this.clientCacheContainer = clientCacheContainer;

            this.serializer = serializer;
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            IByteBuffer byteBuffer = message as IByteBuffer;

            RpcResponse rpcResponse = serializer.Deserialize<RpcResponse>(byteBuffer.ToArray());
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            context.CloseAsync();
        }
    }
}