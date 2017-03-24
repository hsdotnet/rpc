using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Monitor
{
    public class ServerMonitorImpl : IServerMonitor
    {
        public List<RpcService> GetServices()
        {
            return null;
        }

        public Dictionary<long, long> GetStat()
        {
            return null;
        }

        public string Ping()
        {
            return "";
        }
    }
}