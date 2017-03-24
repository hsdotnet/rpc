using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Persist
{
    public class PersistProvider
    {
        private readonly ServerCacheContainer serverCacheContainer;

        public PersistProvider(ServerCacheContainer serverCacheContainer)
        {
            this.serverCacheContainer = serverCacheContainer;
        }

        public void PersistService()
        {

        }
    }
}
