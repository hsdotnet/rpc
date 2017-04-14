using System;
using System.Collections.Generic;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public abstract class AbstractLoadBalance : ILoadBalance
    {
        //public RpcServer GetServer(ClientCacheContainer clientCacheContainer, string appName)
        //{
        //    return new RpcServer() { Host = "172.17.17.43", Port = 8099, Weight = 2 };

        //    List<ClientReferenceServer> referenceServers = clientCacheContainer.ClientReferenceServers.FindAll(m => m.AppName == appName);

        //    if (referenceServers==null || referenceServers.Count==0)
        //    {
        //        throw new Exception("");
        //    }

        //    List<RpcServer> servers = new List<RpcServer>();

        //    foreach (ClientReferenceServer referenceServer in referenceServers)
        //    {
        //        RpcServer server = new RpcServer() { Host = referenceServer.Host, Weight = referenceServer.Weight, Port = referenceServer.Port };

        //        servers.Add(server);
        //    }

        //    return GetServer(servers);
        //}

        //public abstract RpcServer GetServer(List<RpcServer> servers);

        public ServerInfo GetServer(ClientCacheContainer cacheContainer, string appName)
        {
            return new ServerInfo() { Host = "172.17.17.43", Port = 8099, Weight = 2 };
        }

        public abstract ServerInfo GetServer(List<ServerInfo> servers);
    }
}