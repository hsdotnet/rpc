using System;

using Framework.Rpc.Core.Server;

namespace Rpc.Test.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            new RpcServer().Start();

            Console.WriteLine("服务启动成功");

            Console.ReadLine();
        }
    }
}
