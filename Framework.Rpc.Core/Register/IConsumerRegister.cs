using System.Collections.Generic;

using Framework.Rpc.Core.Cluster.LoadBalance;

namespace Framework.Rpc.Core.Register
{
    public interface IConsumerRegister : IRegister
    {
        List<ServerInfo> FindService(string appName);
    }
}