using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Provider;
using Framework.Rpc.Core.Consumer;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Transport;
using Framework.Rpc.Core.Transport.Netty;

namespace Framework.Rpc.Core.Register
{
    public class TransportProvider
    {
        private readonly ServerCacheContainer _serverCacheContainer;

        private readonly ClientCacheContainer _clientCacheContainer;

        private readonly ISerializer _serializer;

        public TransportProvider(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public TransportProvider(ServerCacheContainer serverCacheContainer, ISerializer serializer)
            : this(serializer)
        {
            _serverCacheContainer = serverCacheContainer;
        }

        public TransportProvider(ClientCacheContainer clientCacheContainer, ISerializer serializer)
            : this(serializer)
        {
            _clientCacheContainer = clientCacheContainer;
        }

        public IAcceptor GetAcceptor()
        {
            switch (_serverCacheContainer.Application.Transport)
            {
                case TransportType.Netty:
                default:
                    return new NettyAcceptor(new DefaultProviderProcessor(_serverCacheContainer), _serializer);
            }
        }

        public IConnector GetConnector()
        {
            return new NettyConnector(new DefaultConsumerProcessor(_clientCacheContainer), _serializer);
        }
    }
}