using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Transport
{
    public interface IConsumerProcessor
    {
        void HandleMessage(IChannel channel, RpcResponse response);
    }
}