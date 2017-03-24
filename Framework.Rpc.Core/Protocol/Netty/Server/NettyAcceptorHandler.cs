using System;

using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Server;

using DotNetty.Transport.Channels;
using DotNetty.Buffers;

namespace Framework.Rpc.Core.Protocol.Netty.Server
{
    public class NettyAcceptorHandler : ChannelHandlerAdapter
    {
        private readonly ServerCacheContainer cacheContainer;

        private readonly ISerializer serializer;

        private readonly AbstractServerHandler serverHandler;

        public NettyAcceptorHandler(ServerCacheContainer cacheContainer, ISerializer serializer)
        {
            this.cacheContainer = cacheContainer;

            this.serializer = serializer;

            this.serverHandler = new NettyServerHandler(cacheContainer);
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            IByteBuffer buffer = message as IByteBuffer;

            RpcRequest request = this.serializer.Deserialize<RpcRequest>(buffer.ToArray());

            serverHandler.HandleRequest(request);
            RpcResponse rpcResponse = new ServerProxy().InvokeService(rpcRequest);

            context.WriteAndFlushAsync(NettyByteBufferHelper.GetByteBuffer(serializer, rpcResponse));
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