using Framework.Rpc.Core.Container;
using Framework.Rpc.Core.Serializer;

using ZooKeeperNet;

namespace Framework.Rpc.Core.Register.Zookeeper.Watcher
{
    public class ConsumerWatcher : AbstractWatcher
    {
        public ConsumerWatcher(ZooKeeperNet.ZooKeeper zooKeeper, ClientCacheContainer clientCacheContainer, ISerializer serializer)
            : base(zooKeeper, null, clientCacheContainer, serializer)
        {

        }

        public override void NodeChildrenChanged(WatchedEvent @event)
        {
            
        }

        public override void NodeCreated(WatchedEvent @event)
        {
            //foreach (KeyValuePair<string, List<RpcServer>> item in clientCacheContainer.Servers)
            //{
            //    string path = string.Concat(Constant.ROOT_PATH, Constant.PROVIDER_PATH, item.Key);

            //    if (@event.Path.IndexOf(path) > 0)
            //    {
            //        List<RpcServer> servers = item.Value;

            //        byte[] data = zooKeeper.GetData(@event.Path, false, null);

            //        RpcServer server = serializer.Deserialize<RpcServer>(data);

            //        if (!servers.Contains(server))
            //        {
            //            servers.Add(server);
            //        }

            //        break;
            //    }
            //}
        }

        public override void NodeDataChanged(WatchedEvent @event)
        {
            //foreach (KeyValuePair<string, List<RpcServer>> item in clientCacheContainer.Servers)
            //{
            //    string path = string.Concat(Constant.ROOT_PATH, Constant.PROVIDER_PATH, item.Key);

            //    if (@event.Path == path)
            //    {
            //        IEnumerable<string> childrens = zooKeeper.GetChildren(@event.Path, false);

            //        List<RpcServer> servers = new List<RpcServer>();

            //        foreach (string children in childrens)
            //        {
            //            byte[] data = zooKeeper.GetData(string.Concat(@event.Path, "/", children), false, null);

            //            RpcServer server = serializer.Deserialize<RpcServer>(data);

            //            if (!servers.Contains(server))
            //            {
            //                servers.Add(server);
            //            }
            //        }

            //        clientCacheContainer.Servers.TryUpdate(item.Key, servers, item.Value);

            //        break;
            //    }
            //}
        }

        public override void NodeDeleted(WatchedEvent @event)
        {
            //foreach (KeyValuePair<string, List<RpcServer>> item in clientCacheContainer.Servers)
            //{
            //    string path = string.Concat(Constant.ROOT_PATH, Constant.PROVIDER_PATH, item.Key);

            //    if (@event.Path.IndexOf(path) > 0)
            //    {
            //        List<RpcServer> servers = item.Value;

            //        byte[] data = zooKeeper.GetData(@event.Path, false, null);

            //        RpcServer server = serializer.Deserialize<RpcServer>(data);

            //        if (!servers.Contains(server))
            //        {
            //            servers.Remove(server);
            //        }

            //        break;
            //    }
            //}
        }

        public override void None(WatchedEvent @event)
        {
            
        }
    }
}