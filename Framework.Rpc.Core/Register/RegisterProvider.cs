using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Register.Zookeeper;

namespace Framework.Rpc.Core.Register
{
    public class RegisterProvider
    {
        private readonly ServerCacheContainer serverCacheContainer;

        public IRegister Register { private set; get; }

        public RegisterProvider(ServerCacheContainer serverCacheContainer)
        {
            this.serverCacheContainer = serverCacheContainer;

            InitRegistry();
        }

        private void InitRegistry()
        {
            switch (serverCacheContainer.Application.Register)
            {
                case Registry.RegisterType.Zookeeper:
                default:
                    Register = new ZookeeperRegistry(serverCacheContainer);
                    break;
            }
        }
    }
}