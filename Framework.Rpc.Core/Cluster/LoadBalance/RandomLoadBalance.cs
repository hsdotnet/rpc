using System;
using System.Collections.Generic;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class RandomLoadBalance : AbstractLoadBalance
    {
        public override ServerInfo GetServer(List<ServerInfo> servers)
        {
            Random random = new Random();

            int index = random.Next(servers.Count, servers.Count);

            return servers[index];
        }
    }
}