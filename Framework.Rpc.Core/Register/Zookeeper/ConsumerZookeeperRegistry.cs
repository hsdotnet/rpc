using System.Text;
using System.Collections.Generic;

using Framework.Rpc.Core.Cluster.LoadBalance;

namespace Framework.Rpc.Core.Register.Zookeeper
{
    public class ConsumerZookeeperRegistry : IConsumerRegister
    {
        private readonly ZookeeperInvoker _zookeeperInvoker;

        private readonly ZooKeeperNet.ZooKeeper _zookeeper;

        public ConsumerZookeeperRegistry(string registerAddress)
        {
            _zookeeperInvoker = new ZookeeperInvoker();

            _zookeeper = _zookeeperInvoker.Create(registerAddress, Constant.ZK_SESSION_TIMEOUT, null);
        }

        public void RegisterService()
        {
            _zookeeperInvoker.CreatePersistentNode(_zookeeper, Constant.ROOT_PATH);

            string providerPath = string.Concat(Constant.ROOT_PATH, Constant.CONSUMER_PATH);
            _zookeeperInvoker.CreatePersistentNode(_zookeeper, providerPath);

            //string servicePath = string.Concat(providerPath, "/", _cacheContainer.Application.Name);
            //_zookeeperInvoker.CreatePersistentNode(_zookeeper, servicePath);

            //string address = string.Concat(_cacheContainer.Application.Host, ":", _cacheContainer.Application.Host);
            //_zookeeperInvoker.CreateEphemeralNode(_zookeeper, string.Concat(servicePath, "/", address), address);
        }

        public List<ServerInfo> FindService(string appName)
        {
            List<ServerInfo> serverInfos = new List<ServerInfo>();

            string servicePath = string.Concat(Constant.ROOT_PATH, Constant.PROVIDER_PATH, "/", appName);

            IEnumerable<string> address = _zookeeper.GetChildren(servicePath, false);

            foreach (string addres in address)
            {
                string addressPath = string.Concat(servicePath, "/", addres);

                byte[] bytes = _zookeeper.GetData(addressPath, false, null);

                string addresInfo = Encoding.UTF8.GetString(bytes);

                serverInfos.Add(new ServerInfo()
                {
                    Host = addresInfo.Split(':')[0],
                    Port = int.Parse(addresInfo.Split(':')[0]),
                    Weight = 1
                });
            }

            return serverInfos;
        }
    }
}