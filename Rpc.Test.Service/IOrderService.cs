using System.Threading.Tasks;

using Framework.Rpc.Core.Provider.Attributes;

namespace Rpc.Test.Service
{
    [RpcService("Rpc.Test.Service.IOrderService", "1.0.0")]
    public interface IOrderService
    {
        [RpcMethod("GetOrderNo")]
        string GetOrderNo();

        [RpcMethod("GetOrderNoAsync")]
        Task<string> GetOrderNoAsync();
    }
}