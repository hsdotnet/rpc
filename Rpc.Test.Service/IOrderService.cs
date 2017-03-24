using Framework.Rpc.Core.Server.Attributes;

namespace Rpc.Test.Service
{
    [RpcService("Rpc.Test.Service.IOrderService", "1.0.0")]
    public interface IOrderService
    {
        [RpcMethod("GetOrderNo")]
        string GetOrderNo();
    }
}