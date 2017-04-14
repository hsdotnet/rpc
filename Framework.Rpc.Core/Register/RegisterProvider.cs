using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Register.Zookeeper;

namespace Framework.Rpc.Core.Register
{
    public class RegisterProvider
    {
        public IConsumerRegister GetConsumerRegister(string registerAddress)
        {
            return new ConsumerZookeeperRegistry(registerAddress);
        }

        public IRegister GetRegistry(ServerCacheContainer cacheContainer)
        {
            return new ProviderZookeeperRegistry(cacheContainer);
        }
    }
}