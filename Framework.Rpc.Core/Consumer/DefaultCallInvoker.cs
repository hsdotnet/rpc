using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Transport;

namespace Framework.Rpc.Core.Consumer
{
    public class DefaultCallInvoker : AbstractCallInvoker
    {
        private readonly ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>> _responseDictionary = new ConcurrentDictionary<string, TaskCompletionSource<RpcResponse>>();

        public DefaultCallInvoker(IConsumer consumer) : base(consumer)
        {

        }

        public async override Task<RpcResponse> Call(RpcRequest request)
        {
            try
            {
                var callbackTask = RegisterResultCallbackAsync(request.RequestId);

                try
                {
                    //发送
                    await Consumer.Send(request);
                }
                catch (Exception)
                {

                }

                return await callbackTask;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private Task<RpcResponse> RegisterResultCallbackAsync(string requestId, int timeOut = 5000)
        {
            TaskCompletionSource<RpcResponse> tcs = new TaskCompletionSource<RpcResponse>();

            _responseDictionary.TryAdd(requestId, tcs);

            Task<RpcResponse> task = tcs.Task;

            Task.Factory.StartNew(() =>
            {
                if (Task.WhenAny(task, Task.Delay(timeOut)).Result != task)
                {
                    // timeout logic
                    //TimeOutCallBack(id);
                }
            });
            //设置超时

            return task;
        }

        protected override void MessageRecieved(object sender, RecievedMessageEventArgs e)
        {
            RpcResponse response = e.Response;
            TaskCompletionSource<RpcResponse> tcs;
            if (_responseDictionary.ContainsKey(response.RequestId)
                && _responseDictionary.TryGetValue(response.RequestId, out tcs))
            {
                tcs.TrySetResult(response);
            }
        }
    }
}