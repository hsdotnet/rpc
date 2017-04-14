using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Transport;
using Framework.Rpc.Core.Register;

namespace Framework.Rpc.Core.Provider
{
    public class RpcServer : IServer
    {
        private static ServerSection _section = ConfigHelper.GetSection<ServerSection>();

        private readonly ISerializer _serializer;

        private readonly ServerCacheContainer _cacheContainer;

        private readonly LocalCacheService _localCacheService;

        private readonly IAcceptor _acceptor;

        private readonly TransportProvider _transportProvider;

        public RpcServer()
        {
            _cacheContainer = new ServerCacheContainer();

            _localCacheService = new LocalCacheService(_section, _cacheContainer);

            _serializer = SerializerFactory.GetSerializer(_section.Serializer);

            _transportProvider = new TransportProvider(_cacheContainer, _serializer);

            _acceptor = _transportProvider.GetAcceptor();
        }

        public void Start()
        {
            _localCacheService.CacheService();

            _acceptor.Bind(_cacheContainer.Application.Host, _cacheContainer.Application.Port);
        }

        public void Stop()
        {

        }
    }
}