using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Register.Zookeeper
{
    public class ProviderZookeeperRegistry : IRegister
    {
        private readonly ServerCacheContainer _cacheContainer;

        private readonly ZookeeperInvoker _zookeeperInvoker;

        private readonly ZooKeeperNet.ZooKeeper _zooKeeper;

        public ProviderZookeeperRegistry(ServerCacheContainer cacheContainer)
        {
            _cacheContainer = cacheContainer;

            _zookeeperInvoker = new ZookeeperInvoker();

            _zooKeeper = _zookeeperInvoker.Create(_cacheContainer.Application.RegisterAddress, Constant.ZK_SESSION_TIMEOUT, null);
        }

        public void RegisterService()
        {
            _zookeeperInvoker.CreatePersistentNode(_zooKeeper, Constant.ROOT_PATH);

            string providerPath = string.Concat(Constant.ROOT_PATH, Constant.PROVIDER_PATH);
            _zookeeperInvoker.CreatePersistentNode(_zooKeeper, providerPath);

            string servicePath = string.Concat(providerPath, "/", _cacheContainer.Application.Name);
            _zookeeperInvoker.CreatePersistentNode(_zooKeeper, servicePath);

            string address = string.Concat(_cacheContainer.Application.Host, ":", _cacheContainer.Application.Host);
            _zookeeperInvoker.CreateEphemeralNode(_zooKeeper, string.Concat(servicePath, "/", address), address);
        }
    }
}