using System;
using System.Net;

using Framework.Rpc.Core.Serializer;

using DotNetty.Transport.Channels;
using DotNetty.Buffers;

namespace Framework.Rpc.Core.Transport.Netty
{
    public class NettyChannel : IChannel
    {
        private readonly DotNetty.Transport.Channels.IChannel _channel;

        private readonly IChannelPipeline _pipeline;

        private readonly ISerializer _serializer;

        public NettyChannel(ISerializer serializer, DotNetty.Transport.Channels.IChannel channel)
        {
            _serializer = serializer;

            _channel = channel;

            _pipeline = _channel.Pipeline;
        }

        public void Close()
        {
            try
            {
                _channel.CloseAsync();
            }
            catch (Exception ex)
            {
            }
        }

        public void CloseAutoReconnection()
        {
            throw new NotImplementedException();
        }

        public bool IsActive()
        {
            return _channel.Active;
        }

        public bool IsOpenAutoReconnection()
        {
            throw new NotImplementedException();
        }

        public SocketAddress LocalAddress()
        {
            return _channel.LocalAddress.Serialize();
        }

        public void OpenAutoReconnection()
        {
            throw new NotImplementedException();
        }

        public SocketAddress RemoteAddress()
        {
            return _channel.RemoteAddress.Serialize();
        }

        public IChannel Write(object message)
        {
            byte[] data = _serializer.Serialize(message);

            var buffer = Unpooled.Buffer(data.Length, data.Length);

            _channel.WriteAndFlushAsync(buffer.WriteBytes(data));

            return new NettyChannel(_serializer, _channel);
        }

        public IChannel Write(object message, IChannelListener listener)
        {
            throw new NotImplementedException();
        }
    }
}