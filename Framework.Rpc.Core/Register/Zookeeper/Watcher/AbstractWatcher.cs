using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;

using ZooKeeperNet;

namespace Framework.Rpc.Core.Register.Zookeeper.Watcher
{
    public abstract class AbstractWatcher : IWatcher
    {
        protected readonly ZooKeeper _zookeeper;

        protected readonly ServerCacheContainer _serverCacheContainer;

        protected readonly ClientCacheContainer _clientCacheContainer;

        protected readonly ISerializer _serializer;

        public AbstractWatcher(ZooKeeper zookeeper, ISerializer serializer)
        {
            _zookeeper = zookeeper;

            _serializer = serializer;
        }

        public AbstractWatcher(ZooKeeper zookeeper, ClientCacheContainer clientCacheContainer, ISerializer serializer)
            : this(zookeeper, serializer)
        {
            _clientCacheContainer = clientCacheContainer;
        }

        public AbstractWatcher(ZooKeeper zookeeper, ServerCacheContainer serverCacheContainer, ISerializer serializer)
            : this(zookeeper, serializer)
        {
            _serverCacheContainer = serverCacheContainer;
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