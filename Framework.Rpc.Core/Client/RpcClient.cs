using System;

using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Protocol.Netty.Client;

namespace Framework.Rpc.Core.Client
{
    public class RpcClient
    {
        private static ClientSection clientSection = ConfigHelper.GetSection<ClientSection>();

        [ThreadStatic]
        private static ClientCacheContainer clientCacheContainer = new ClientCacheContainer();

        private static IClient InitClient()
        {
            IClient client = null;

            ILoadBalance loadBalance = LoadBalanceFactory.GetLoadBalance(clientSection.LoadBalance);

            ISerializer serializer = SerializerFactory.GetSerializer(clientSection.Serializer);

            switch (clientSection.Protocol)
            {
                case Protocol.ProtocolType.Netty:
                default:
                    client = new NettyClient(clientCacheContainer, loadBalance, serializer);
                    break;
            }

            return client;
        }

        public static T GetService<T>()
        {
            T service = (T)new ClientProxy<T>(InitClient()).GetTransparentProxy();

            return service;
        }
    }
}