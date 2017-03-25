using System;
using System.Collections.Concurrent;

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

        private readonly BlockingCollection<RpcResponse> answer = new BlockingCollection<RpcResponse>();

        public RpcResponse GetResponse() => this.answer.Take();

        public NettyAcceptorHandler(ClientCacheContainer clientCacheContainer, ISerializer serializer)
        {
            this.clientCacheContainer = clientCacheContainer;

            this.serializer = serializer;
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            IByteBuffer byteBuffer = message as IByteBuffer;

            RpcResponse response = serializer.Deserialize<RpcResponse>(byteBuffer.ToArray());

            context.CloseAsync().ContinueWith(t => this.answer.Add(response));
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