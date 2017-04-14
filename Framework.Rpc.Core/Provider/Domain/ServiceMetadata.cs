using System;
using System.Collections.Generic;

namespace Framework.Rpc.Core.Provider.Domain
{
    public class ServiceMetadata
    {
        public string ServiceName { get; set; }

        public Type ServiceType { get; set; }

        public Type ServiceImplType { get; set; }

        public List<MethodMetadata> MethodMetadatas { get; set; }

        public ServiceMetadata()
        {
            MethodMetadatas = new List<MethodMetadata>();
        }
    }
}