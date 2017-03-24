using System;

using Framework.Rpc.Core.Client;

using Rpc.Test.Service;

namespace Rpc.Test.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderService orderService = RpcClient.GetService<IOrderService>();

            string orderNo = orderService.GetOrderNo();

            Console.WriteLine(orderNo);
        }
    }
}
