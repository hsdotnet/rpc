namespace Framework.Rpc.Core.Transport
{
    public interface IConnector
    {
        IChannel Connect(string host, int port);

        void Processor(IProviderProcessor processor);

        void ShutdownGracefully();
    }
}