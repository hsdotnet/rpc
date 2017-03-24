using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Protocol;

namespace Framework.Rpc.Core.Client
{
    public interface IClient
    {
        RpcResponse Send(RpcRequest request);

        IAcceptor Acceptor { get; set; }
    }
}