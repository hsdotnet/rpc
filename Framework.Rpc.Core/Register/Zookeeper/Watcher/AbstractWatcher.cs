using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;

using ZooKeeperNet;

namespace Framework.Rpc.Core.Register.Zookeeper.Watcher
{
    public abstract class AbstractWatcher : IWatcher
    {
        protected readonly ZooKeeperNet.ZooKeeper zookeeper;

        protected readonly ServerCacheContainer serverCacheContainer;

        protected readonly ClientCacheContainer clientCacheContainer;

        protected readonly ISerializer serializer;

        public AbstractWatcher(ZooKeeperNet.ZooKeeper zookeeper, ServerCacheContainer serverCacheContainer, ClientCacheContainer clientCacheContainer, ISerializer serializer)
        {
            this.zookeeper = zookeeper;

            this.serverCacheContainer = serverCacheContainer;

            this.clientCacheContainer = clientCacheContainer;

            this.serializer = serializer;
        }

        public void Process(WatchedEvent @event)
        {
            switch (@event.Type)
            {
                case EventType.None:
                    None(@event);
                    break;
                case EventType.NodeCreated:
                    None(@event);
                    break;
                case EventType.NodeDeleted:
                    None(@event);
                    break;
                case EventType.NodeDataChanged:
                    None(@event);
                    break;
                case EventType.NodeChildrenChanged:
                    NodeChildrenChanged(@event);
                    break;
                default:
                    break;
            }
        }

        public abstract void None(WatchedEvent @event);

        public abstract void NodeCreated(WatchedEvent @event);

        public abstract void NodeDeleted(WatchedEvent @event);

        public abstract void NodeDataChanged(WatchedEvent @event);

        public abstract void NodeChildrenChanged(WatchedEvent @event);
    }
}