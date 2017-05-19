using System.Threading.Tasks;

using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Transport;
using Framework.Rpc.Core.Cluster.LoadBalance;
using Framework.Rpc.Core.Serializer;
using Framework.Rpc.Core.Register;
using System;

namespace Framework.Rpc.Core.Consumer
{
    public abstract class AbstractConsumer : IConsumer
    {
        protected readonly ClientCacheContainer _cacheContainer;

        protected readonly ISerializer _serializer;

        protected readonly ILoadBalance _loadBalance;

        private readonly TransportProvider _transportProvider;

        private readonly IMessageHandler _handler;

        protected readonly IConnector _connector;

        public event EventHandler<RecievedMessageEventArgs> Recieved;

        public AbstractConsumer(IMessageHandler handler, ClientCacheContainer cacheContainer, ILoadBalance loadBalance, ISerializer serializer)
        {
            _handler = handler;

            _handler.Recieved += Message_Recieved;

            _cacheContainer = cacheContainer;

            _loadBalance = loadBalance;

            _serializer = serializer;

            _transportProvider = new TransportProvider(_cacheContainer, serializer);

            _connector = _transportProvider.GetConnector(_handler);
        }

        private void Message_Recieved(object sender, RecievedMessageEventArgs e)
        {
            Recieved?.Invoke(sender, e);
        }

        public Task Send(RpcRequest request)
        {
            ServerInfo server = _loadBalance.GetServer(request.AppName);

            IChannel channel = _connector.Connect(server.Host, server.Port);

            return DoSend(channel, request);
        }

        public abstract Task DoSend(IChannel channel, RpcRequest request);
    }
}