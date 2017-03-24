using System;
using System.Collections.Generic;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public class RandomLoadBalance : AbstractLoadBalance
    {
        public override RpcServer GetServer(List<RpcServer> servers)
        {
            Random random = new Random();

            int index = random.Next(servers.Count, servers.Count);

            return servers[index];
        }
    }
}