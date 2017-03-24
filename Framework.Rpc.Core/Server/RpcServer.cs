using System.Collections.Generic;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Protocol;
using Framework.Rpc.Core.Register;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Persist;

namespace Framework.Rpc.Core.Server
{
    public class RpcServer : IServer
    {
        private static ServerSection section = ConfigHelper.GetSection<ServerSection>();

        private ISerializer serializer;

        private readonly ServerCacheContainer serverCacheContainer;

        private readonly LocalCacheService localCacheService;

        private ProtocolProvider protocolProvider;

        private RegisterProvider registerProvider;

        private PersistProvider persistProvider;

        public List<IInterceptor> Interceptors { get; }

        public RpcServer()
        {
            serverCacheContainer = new ServerCacheContainer();

            localCacheService = new LocalCacheService(section, serverCacheContainer);

            Interceptors = new List<IInterceptor>();
        }

        public void AddInterceptor(IInterceptor interceptor)
        {
            Interceptors.Add(interceptor);
        }

        public void Start()
        {
            localCacheService.CacheService();

            serializer = SerializerFactory.GetSerializer(serverCacheContainer.Application.Serializer);

            protocolProvider = new ProtocolProvider(serverCacheContainer, serializer);

            registerProvider = new RegisterProvider(serverCacheContainer);

            persistProvider = new PersistProvider(serverCacheContainer);

            protocolProvider.Acceptor.Start();

            registerProvider.Register.RegisterService();

            persistProvider.PersistService();
        }

        public void Stop()
        {
            protocolProvider.Acceptor.Stop();
        }
    }
}