namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class LoadBalanceFactory
    {
        public static ILoadBalance GetLoadBalance(LoadBalanceType type)
        {
            switch (type)
            {
                case LoadBalanceType.Random:
                default:
                    return new RandomLoadBalance();
            }
        }
    }
}