using System.Collections.Generic;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Monitor
{
    /// <summary>
    /// 服务提供者性能监控，provider内置
    /// </summary>
    public interface IServerMonitor : IMonitor
    {
        List<RpcService> GetServices();

        string Ping();
    }
}