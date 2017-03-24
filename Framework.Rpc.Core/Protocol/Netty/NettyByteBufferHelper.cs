using Framework.Rpc.Core.Serializer;

using DotNetty.Buffers;

namespace Framework.Rpc.Core.Protocol.Netty
{
    public class NettyByteBufferHelper
    {
        public static IByteBuffer GetByteBuffer<T>(ISerializer serializer, T t)
        {
            byte[] data = serializer.Serialize<T>(t);

            var buffer = Unpooled.Buffer(data.Length, data.Length);

            return buffer.WriteBytes(data);
        }
    }
}