using System;

using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;

using ZooKeeperNet;

namespace Framework.Rpc.Core.Register.Zookeeper.Watcher
{
    public class ProviderWatcher : AbstractWatcher
    {
        private ProviderWatcher(ZooKeeperNet.ZooKeeper zookeeper, ClientCacheContainer clientCacheContainer, ISerializer serializer)
            : base(zookeeper, null, clientCacheContainer, serializer)
        {

        }

        public override void NodeChildrenChanged(WatchedEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void NodeCreated(WatchedEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void NodeDataChanged(WatchedEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void NodeDeleted(WatchedEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void None(WatchedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}