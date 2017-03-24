using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Client
{
    public class ClientProxy<T> : RealProxy
    {
        private readonly IClient client;

        public ClientProxy(IClient client) : base(typeof(T))
        {
            this.client = client;
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

            RpcResponse response = client.Send(request);

            return new ReturnMessage(response.Result, null, 0, callMessage.LogicalCallContext, callMessage);
        }
    }
}