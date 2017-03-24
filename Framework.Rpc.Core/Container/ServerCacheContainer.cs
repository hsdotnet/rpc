using System.Collections.Generic;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Container
{
    public class ServerCacheContainer
    {
        public RpcApplication Application { get; set; }

        public Dictionary<string, RpcServiceMetadata> ServiceMetadatas { get; set; }

        public ServerCacheContainer()
        {
            Application = new RpcApplication();

            ServiceMetadatas = new Dictionary<string, RpcServiceMetadata>();
        }
    }
}