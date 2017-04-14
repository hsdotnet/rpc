using System.Collections.Generic;

namespace Framework.Rpc.Core.Provider
{
    public interface IServer
    {
        void Start();

        void Stop();

        //List<IInterceptor> Interceptors { get; }
    }
}