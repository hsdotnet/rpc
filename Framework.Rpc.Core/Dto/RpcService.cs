namespace Framework.Rpc.Core.Dto
{
    /// <summary>
    /// 服务名称，版本，实现类，以及服务启动时间
    /// 用于存储zookeeper或者etcd，方便服务发现，json存储
    /// </summary>
    public class RpcService
    {
        /// <summary>
        /// 服务名称，取Impl类实现的接口Class全名
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务版本，方便服务升级
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 服务实现类
        /// </summary>
        public string ServiceImpl { get; set; }

        /// <summary>
        /// 服务启动时间，用于监控与统计
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// 所属应用,用于应用标记
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// 应用部署分组,用于业务隔离
        /// </summary>
        public string GroupName { get; set; }

        public RpcService()
        {

        }

        public RpcService(string serviceName, string version)
        {
            ServiceName = serviceName;
            Version = version;
        }

        public RpcService(string serviceName, string version, string serviceImpl)
            : this(serviceName, version)
        {
            ServiceImpl = serviceImpl;
        }
    }
}
