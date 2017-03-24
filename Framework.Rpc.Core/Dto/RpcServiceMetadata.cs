using System;
using System.Reflection;

namespace Framework.Rpc.Core.Dto
{
    public class RpcServiceMetadata
    {
        public string ServiceName { get; set; }

        //public string MethodName { get; set; }

        //public string AppName { get; set; }

        public Type ServiceType { get; set; }

        public Type ServiceImplType { get; set; }

        //public MethodInfo Method { get; set; }
    }
}