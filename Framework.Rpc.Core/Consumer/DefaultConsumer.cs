using System.Threading.Tasks;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;

namespace Framework.Rpc.Core.Consumer
{
    public class DefaultConsumer : AbstractConsumer
    {
        public DefaultConsumer(ClientCacheContainer cacheContainer, ILoadBalance loadBalance, ISerializer serializer)
            : base(cacheContainer, loadBalance, serializer)
        {

        }

        public override RpcResponse DoSend(IChannel channel, RpcRequest request)
        {
            TaskCompletionSource<RpcResponse> taskCompletionSource = new TaskCompletionSource<RpcResponse>();

            _cacheContainer.ResponseBag.TryAdd(request.RequestId, taskCompletionSource);

            channel.Write(request);

            if (!taskCompletionSource.Task.Wait(1000 * 10))
            {
                _cacheContainer.ResponseBag.TryRemove(request.RequestId, out taskCompletionSource);

                //throw new TimeoutException("timeout, cause by waiting for reply ！");
            }

            _cacheContainer.ResponseBag.TryRemove(request.RequestId, out taskCompletionSource);

            return taskCompletionSource.Task.Result;
        }
    }
}