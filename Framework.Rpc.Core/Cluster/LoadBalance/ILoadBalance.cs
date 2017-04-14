namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public interface ILoadBalance
    {
        ServerInfo GetServer(string appName);
    }
}