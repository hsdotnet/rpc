using System;
using System.Collections.Generic;

using Framework.Rpc.Core.Register;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class RandomLoadBalance : AbstractLoadBalance
    {
        public RandomLoadBalance(IConsumerRegister register) : base(register)
        {

        }

        public override ServerInfo DoGetServer(List<ServerInfo> serverInfos)
        {
            Random random = new Random();

            int index = random.Next(serverInfos.Count, serverInfos.Count);

            return serverInfos[index];
        }
    }
}