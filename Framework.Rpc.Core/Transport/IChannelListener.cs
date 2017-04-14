namespace Framework.Rpc.Core.Transport
{
    public interface IChannelListener
    {
        void OperationSuccess(IChannel channel);

        void OperationFailure(IChannel channel);
    }
}
