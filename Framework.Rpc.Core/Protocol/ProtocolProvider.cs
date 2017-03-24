using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Protocol.Netty.Server;
using Framework.Rpc.Core.Serializer;

namespace Framework.Rpc.Core.Protocol
{
    public class ProtocolProvider
    {
        private readonly ServerCacheContainer serverCacheContainer;

        private readonly ISerializer serializer;

        public IAcceptor Acceptor { private set; get; }

        public ProtocolProvider(ServerCacheContainer serverCacheContainer, ISerializer serializer)
        {
            this.serverCacheContainer = serverCacheContainer;

            this.serializer = serializer;

            InitAcceptor();
        }

        private void InitAcceptor()
        {
            switch (serverCacheContainer.Application.Protocol)
            {
                case ProtocolType.Netty:
                default:
                    Acceptor = new NettyAcceptor(serverCacheContainer, serializer);
                    break;
            }
        }
    }
}