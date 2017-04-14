using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public interface ILoadBalance
    {
        ServerInfo GetServer(ClientCacheContainer cacheContainer, string appName);
    }
}