using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Transport
{
    public interface IProviderProcessor
    {
        void HandleMessage(IChannel channel, RpcRequest request);
    }
}