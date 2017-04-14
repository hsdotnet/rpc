using System.Net;

namespace Framework.Rpc.Core.Transport
{
    public interface IChannel
    {
        SocketAddress LocalAddress();

        SocketAddress RemoteAddress();

        bool IsActive();

        IChannel Write(object message);

        IChannel Write(object message, IChannelListener listener);

        void OpenAutoReconnection();

        void CloseAutoReconnection();

        bool IsOpenAutoReconnection();

        void Close();
    }
}