using System;
using System.Threading.Tasks;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Consumer
{
    public class ConsumerMessageHandler : IMessageHandler
    {
        public event EventHandler<RecievedMessageEventArgs> Recieved;

        public Task ReceiveAsync(RpcResponse response)
        {
            if (Recieved != null)
            {
                return Task.Factory.StartNew(() => { Recieved.Invoke(this, new RecievedMessageEventArgs(response)); });
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}