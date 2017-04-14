using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Consumer
{
    public class ConsumerProxy<T> : RealProxy
    {
        private readonly IConsumer _consumer;

        public ConsumerProxy(IConsumer consumer) : base(typeof(T))
        {
            _consumer = consumer;
        }

        public override IMessage Invoke(IMessage message)
        {
            IMethodCallMessage callMessage = (IMethodCallMessage)message;

            MethodInfo method = (MethodInfo)callMessage.MethodBase;

            RpcRequest request = new RpcRequest()
            {
                AppName = "Framework.Rpc.Test",
                MethodName = method.Name,
                ServiceName = typeof(T).FullName,
                Parameters = callMessage.Args
            };

            RpcResponse response = _consumer.Send(request);

            return new ReturnMessage(response.Result, null, 0, callMessage.LogicalCallContext, callMessage);
        }
    }
}
