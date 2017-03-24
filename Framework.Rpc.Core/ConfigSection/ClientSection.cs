using Framework.Rpc.Core.Cluster.LoadBalance;

namespace Framework.Rpc.Core.ConfigSection
{
    public class ClientSection : BaseSection
    {
        public LoadBalanceType LoadBalance { get; set; }
    }
}