using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core
{
    public class RecievedMessageEventArgs
    {
        public RecievedMessageEventArgs()
        {

        }

        public RecievedMessageEventArgs(RpcResponse response)
        {
            Response = response;
        }

        public RpcResponse Response { get; set; }
    }
}