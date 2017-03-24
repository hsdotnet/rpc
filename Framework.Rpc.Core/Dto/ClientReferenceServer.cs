namespace Framework.Rpc.Core.Dto
{
    public class ClientReferenceServer : RpcServer
    {
        public string AppName { get; set; }

        public object Connection { get; set; }
    }
}