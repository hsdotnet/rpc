using System;

namespace Framework.Rpc.Core.Dto
{
    [Serializable]
    public class RpcResponse
    {
        public string RequestId { get; set; }

        public Exception Error { get; set; }

        public object Result { get; set; }
    }
}