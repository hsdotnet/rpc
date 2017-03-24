namespace Framework.Rpc.Core.Dto
{
    public class RpcClientConnection
    {
        public string Host { get; private set; }

        public int Port { get; private set; }

        public object Connection { get; private set; }

        public RpcClientConnection(string host, int port, object connection)
        {
            Host = host;
            Port = port;
            Connection = connection;
        }
    }
}