using System;
using System.Text;

using ZooKeeperNet;
using Org.Apache.Zookeeper.Data;

namespace Framework.Rpc.Core.Register.Zookeeper
{
    public class ZookeeperInvoker
    {
        /// <summary>
        /// 创建ZooKeeper客户端实例
        /// </summary>
        /// <param name="connectstring"></param>
        /// <param name="sessionTimeout"></param>
        /// <param name="watcher"></param>
        /// <returns></returns>
        public ZooKeeper Create(string connectstring, int sessionTimeout, IWatcher watcher)
        {
            ZooKeeper zookeeper = new ZooKeeper(connectstring, new TimeSpan(0, 0, 0, sessionTimeout), watcher);

            return zookeeper;
        }

        /// <summary>
        /// 关闭ZooKeeper客户端连接
        /// </summary>
        /// <param name="zookeeper"></param>
        public void close(ZooKeeper zookeeper)
        {
            zookeeper.Dispose();
        }

        /// <summary>
        /// 判断stat是否存在
        /// </summary>
        /// <param name="zookeeper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stat GetPathStat(ZooKeeper zookeeper, string path)
        {
            return zookeeper.Exists(path, false);
        }

        public void CreatePersistentNode(ZooKeeper zookeeper, string path)
        {
            Stat stat = GetPathStat(zookeeper, path);
            if (stat == null)
                zookeeper.Create(Constant.ROOT_PATH, new byte[] { }, Ids.OPEN_ACL_UNSAFE, CreateMode.Persistent);
        }

        public void CreateEphemeralNode(ZooKeeper zookeeper, string path, string address)
        {
            Stat stat = GetPathStat(zookeeper, path);
            if (stat == null)
                zookeeper.Create(path, Encoding.UTF8.GetBytes(address), Ids.OPEN_ACL_UNSAFE, CreateMode.Ephemeral);
        }
    }
}