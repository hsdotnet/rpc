using System.Collections.Generic;

using Framework.Rpc.Core.Dto;

namespace Framework.Rpc.Core.Register
{
    public interface IRegister
    {
        void RegisterService();

        List<RpcServer> DiscoverService(string appName);
    }
}
