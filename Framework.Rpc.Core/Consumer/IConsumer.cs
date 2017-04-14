using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;

namespace Framework.Rpc.Core.Consumer
{
    public interface IConsumer
    {
        RpcResponse Send(RpcRequest request);
    }
}
