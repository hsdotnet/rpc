using System.Net;
using System.Threading.Tasks;

namespace Framework.Rpc.Core.Transport
{
    public interface IChannel
    {
        SocketAddress LocalAddress();

        SocketAddress RemoteAddress();

        bool IsActive();

        Task Write(object message);

        Task Write(object message, IChannelListener listener);

        void OpenAutoReconnection();

        void CloseAutoReconnection();

        bool IsOpenAutoReconnection();

        void Close();
    }
}