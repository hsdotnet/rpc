using System;
using System.Collections.Generic;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public abstract class AbstractLoadBalance : ILoadBalance
    {
        public RpcServer GetServer(ClientCacheContainer clientCacheContainer, string appName)
        {
            return new RpcServer() { Host = "192.168.1.103", Port = 8099, Weight = 2 };

            List<ClientReferenceServer> referenceServers = clientCacheContainer.ClientReferenceServers.FindAll(m => m.AppName == appName);

            if (referenceServers==null || referenceServers.Count==0)
            {
                throw new Exception("");
            }

            List<RpcServer> servers = new List<RpcServer>();

            foreach (ClientReferenceServer referenceServer in referenceServers)
            {
                RpcServer server = new RpcServer() { Host = referenceServer.Host, Weight = referenceServer.Weight, Port = referenceServer.Port };

                servers.Add(server);
            }

            return GetServer(servers);
        }

        public abstract RpcServer GetServer(List<RpcServer> servers);
    }
}