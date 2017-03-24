using System.Collections.Generic;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Container
{
    public class ClientCacheContainer
    {
        public List<ClientReferenceServer> ClientReferenceServers { get; set; }

        public ClientCacheContainer()
        {
            ClientReferenceServers = new List<ClientReferenceServer>();
        }
    }
}