using System.Threading.Tasks;

using Framework.Rpc.Core.Consumer;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core
{
    public abstract class AbstractCallInvoker
    {
        private readonly IConsumer _consumer;

        public AbstractCallInvoker(IConsumer consumer)
        {
            _consumer = consumer;
            _consumer.Recieved += MessageRecieved;
        }

        protected IConsumer Consumer { get { return _consumer; } }

        protected abstract void MessageRecieved(object sender, RecievedMessageEventArgs e);

        public abstract Task<RpcResponse> Call(RpcRequest request);
    }
}