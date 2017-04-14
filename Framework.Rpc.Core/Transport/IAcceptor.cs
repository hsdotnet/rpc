namespace Framework.Rpc.Core.Transport
{
    public interface IAcceptor
    {
        IChannel Bind(string host, int port);
    }
}
