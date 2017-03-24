using System.Collections.Generic;

namespace Framework.Rpc.Core.Monitor
{
    /// <summary>
    /// 统计监控值
    /// </summary>
    public interface IMonitor
    {
        Dictionary<long, long> GetStat();
    }
}