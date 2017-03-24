using DotNetty.Handlers.Timeout;
using DotNetty.Transport.Channels;

namespace Framework.Rpc.Core.Protocol.Netty.Handler
{
    public class IdleHeartBeatHandler : IdleStateHandler
    {
        public IdleHeartBeatHandler(int readerIdleTimeSeconds, int writerIdleTimeSeconds,
                                int allIdleTimeSeconds) : base(readerIdleTimeSeconds, writerIdleTimeSeconds, allIdleTimeSeconds)
        {
            
        }

        
    }
}