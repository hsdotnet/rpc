using Framework.Rpc.Core.Provider.Domain;

namespace Framework.Rpc.Core.Container
{
    public class ServerCacheContainer
    {
        public Application Application { get; set; }

        public ServerCacheContainer()
        {
            Application = new Application();
        }
    }
}