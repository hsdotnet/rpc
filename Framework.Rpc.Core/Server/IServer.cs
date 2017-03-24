using System.Collections.Generic;

namespace Framework.Rpc.Core.Server
{
    public interface IServer : IService
    {
        List<IInterceptor> Interceptors { get; }
    }
}