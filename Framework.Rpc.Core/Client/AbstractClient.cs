using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Protocol;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;

namespace Framework.Rpc.Core.Client
{
    public abstract class AbstractClient : IClient
    {
        protected readonly ClientCacheContainer clientCacheContainer;

        protected readonly ISerializer serializer;

        protected readonly ILoadBalance loadBalance;

        public IAcceptor Acceptor { get; set; }

        public AbstractClient(ClientCacheContainer clientCacheContainer, ILoadBalance loadBalance, ISerializer serializer)
        {
            this.clientCacheContainer = clientCacheContainer;

            this.loadBalance = loadBalance;

            this.serializer = serializer;
        }

        public RpcResponse Send(RpcRequest request)
        {
            RpcServer server = loadBalance.GetServer(clientCacheContainer, request.AppName);

            ClientReferenceServer referenceServer = new ClientReferenceServer() { AppName = request.AppName, Port = server.Port, Host = server.Host, Weight = server.Weight };

            SetAcceptor(referenceServer);

            return DoSend(request, GetReferenceServer(server));
        }

        private ClientReferenceServer GetReferenceServer(RpcServer server)
        {
            ClientReferenceServer currentServer = null;

            foreach (ClientReferenceServer referenceServer in clientCacheContainer.ClientReferenceServers)
            {
                if (referenceServer.Host == server.Host && referenceServer.Port == server.Port)
                {
                    currentServer = referenceServer;

                    break;
                }
            }

            if (currentServer == null)
            {
                Acceptor.Start();

                return GetReferenceServer(server);
            }

            if (currentServer != null && currentServer.Connection == null)
            {
                clientCacheContainer.ClientReferenceServers.Remove(currentServer);

                Acceptor.Start();

                return GetReferenceServer(server);
            }

            return currentServer;
        }

        public abstract void SetAcceptor(ClientReferenceServer referenceServer);

        public abstract RpcResponse DoSend(RpcRequest request, ClientReferenceServer referenceServer);
    }
}