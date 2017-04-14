namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class ServerInfo
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public int Weight { get; set; }
    }
}