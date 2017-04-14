using Framework.Rpc.Core.Serializer;

using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace Framework.Rpc.Core.Transport.Netty
{
    public abstract class AbstractChannelHandlerAdapter<T> : ChannelHandlerAdapter
    {
        protected readonly ISerializer _serializer;

        protected AbstractChannelHandlerAdapter(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            IByteBuffer byteBuffer = message as IByteBuffer;

            T t = _serializer.Deserialize<T>(byteBuffer.ToArray());

            DoChannelRead(context, t);
        }

        public abstract void DoChannelRead(IChannelHandlerContext context, T message);
    }
}