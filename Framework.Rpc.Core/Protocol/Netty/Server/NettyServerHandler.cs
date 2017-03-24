using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Server;

namespace Framework.Rpc.Core.Protocol.Netty.Server
{
    public class NettyServerHandler : AbstractServerHandler
    {
        public NettyServerHandler(ServerCacheContainer cacheContainer) :
            base(cacheContainer)
        {
        }
    }
}