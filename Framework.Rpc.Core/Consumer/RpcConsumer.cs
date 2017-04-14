using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;

namespace Framework.Rpc.Core.Consumer
{
    public class RpcConsumer
    {
        private static ClientSection _section = ConfigHelper.GetSection<ClientSection>();

        private static ClientCacheContainer _cacheContainer = new ClientCacheContainer();

        private static ISerializer _serializer = SerializerFactory.GetSerializer(_section.Serializer);

        private static ILoadBalance _loadBalance = LoadBalanceFactory.GetLoadBalance(_section.LoadBalance);

        public static T GetService<T>()
        {
            IConsumer consumer = new DefaultConsumer(_cacheContainer, _loadBalance, _serializer);

            T service = (T)new ConsumerProxy<T>(consumer).GetTransparentProxy();

            return service;
        }
    }
}