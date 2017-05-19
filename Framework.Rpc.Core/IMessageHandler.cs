using System;
using System.Threading.Tasks;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core
{
    public interface IMessageHandler
    {
        Task ReceiveAsync(RpcResponse response);

        event EventHandler<RecievedMessageEventArgs> Recieved;
    }
}