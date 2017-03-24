using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public interface ILoadBalance
    {
        RpcServer GetServer(ClientCacheContainer clientCacheContainer, string appName);
    }
}