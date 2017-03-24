using System;

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
        public ZooKeeperNet.ZooKeeper Create(string connectstring, int sessionTimeout, IWatcher watcher)
        {
            ZooKeeperNet.ZooKeeper zookeeper = new ZooKeeperNet.ZooKeeper(connectstring, new TimeSpan(0, 0, 0, sessionTimeout), watcher);

            return zookeeper;
        }

        /// <summary>
        /// 关闭ZooKeeper客户端连接
        /// </summary>
        /// <param name="zookeeper"></param>
        public void close(ZooKeeperNet.ZooKeeper zookeeper)
        {
            zookeeper.Dispose();
        }

        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        /// <param name="zookeeper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool PathExist(ZooKeeperNet.ZooKeeper zookeeper, string path)
        {
            return GetPathStat(zookeeper, path) != null;
        }

        /// <summary>
        /// 判断stat是否存在
        /// </summary>
        /// <param name="zookeeper"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public Stat GetPathStat(ZooKeeperNet.ZooKeeper zookeeper, string path)
        {
            return zookeeper.Exists(path, false);
        }
    }
}