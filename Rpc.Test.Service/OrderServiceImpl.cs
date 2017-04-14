using System;

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
    }
}