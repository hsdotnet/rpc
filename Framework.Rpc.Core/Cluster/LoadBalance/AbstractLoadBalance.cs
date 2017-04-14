using System.Collections.Generic;

using Framework.Rpc.Core.Register;

namespace Framework.Rpc.Core.Cluster.LoadBalance
{
    public abstract class AbstractLoadBalance : ILoadBalance
    {
        private readonly IConsumerRegister _register;

        public AbstractLoadBalance(IConsumerRegister register)
        {
            _register = register;
        }

        public ServerInfo GetServer(string appName)
        {
            //return new ServerInfo() { Host = "172.17.17.43", Port = 8099, Weight = 2 };

            List<ServerInfo> serverInfos = _register.FindService(appName);

            return DoGetServer(serverInfos);
        }

        public abstract ServerInfo DoGetServer(List<ServerInfo> serverInfos);
    }
}