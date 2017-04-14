using Framework.Rpc.Core.Register;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class LoadBalanceFactory
    {
        public static ILoadBalance GetLoadBalance(LoadBalanceType type, IConsumerRegister consumerRegister)
        {
            switch (type)
            {
                case LoadBalanceType.Random:
                default:
                    return new RandomLoadBalance(consumerRegister);
            }
        }
    }
}