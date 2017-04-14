using System.Collections.Generic;

using Framework.Rpc.Core.Dto;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Framework.Rpc.Core.Container
{
    public class ClientCacheContainer
    {
        public ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>> ResponseBag { get; set; }

        public List<ClientReferenceServer> ClientReferenceServers { get; set; }

        public ClientCacheContainer()
        {
            ResponseBag = new ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>>();

            ClientReferenceServers = new List<ClientReferenceServer>();
        }
    }
}