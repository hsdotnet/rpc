using System;
using System.Threading.Tasks;
using Framework.Rpc.Core.Provider.Attributes;

namespace Rpc.Test.Service
{
    [RpcServiceImpl]
    public class OrderServiceImpl : IOrderService
    {
        public string GetOrderNo()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public Task<string> GetOrderNoAsync()
        {
            return Task<string>.Factory.StartNew(() => { return "abc"; });
        }
    }
}