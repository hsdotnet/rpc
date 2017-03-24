using System.Collections.Generic;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Register.Zookeeper
{
    public class ZookeeperRegistry : IRegister
    {
        private readonly ServerCacheContainer serverCacheContainer;

        public ZookeeperRegistry(ServerCacheContainer serverCacheContainer)
        {
            this.serverCacheContainer = serverCacheContainer;
        }

        public List<RpcServer> DiscoverService(string appName)
        {
            return null;
        }

        public void RegisterService()
        {
            
        }
    }
}