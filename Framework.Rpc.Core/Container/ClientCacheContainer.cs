using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Container
{
    public class ClientCacheContainer
    {
        public ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>> ResponseBag { get; set; }

        public List<ReferenceServer> ReferenceServers { get; set; }

        public ClientCacheContainer()
        {
            ResponseBag = new ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>>();

            ReferenceServers = new List<ReferenceServer>();
        }
    }
}