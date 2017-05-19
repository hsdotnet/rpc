using System;

using Framework.Rpc.Core.Consumer;

using Rpc.Test.Service;

namespace Rpc.Test.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderService orderService = RpcConsumer.GetService<IOrderService>();

            var orderNo = orderService.GetOrderNo();

            Console.WriteLine(orderNo);
        }
    }
}
