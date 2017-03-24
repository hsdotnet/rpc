using System;
using System.Reflection;

using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Dto;
using Framework.Rpc.Core.Helper;
using Framework.Rpc.Core.Server.Attributes;
using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Server
{
    public class LocalCacheService
    {
        private readonly ServerSection section;

        private readonly ServerCacheContainer cacheContainer;

        public LocalCacheService(ServerSection section, ServerCacheContainer cacheContainer)
        {
            this.section = section;

            this.cacheContainer = cacheContainer;
        }

        /// <summary>
        /// 缓存Service到本地
        /// </summary>
        public void CacheService()
        {
            InitApplication();

            InitServiceMetadata();

            InitServiceMethod();
        }

        private void InitApplication()
        {
            cacheContainer.Application.Name = section.AppName;
            cacheContainer.Application.Port = section.Port;
            cacheContainer.Application.Host = NetworkHelper.GetLocalIPAddress();
            cacheContainer.Application.Time = 0;
            cacheContainer.Application.Protocol = section.Protocol;
            cacheContainer.Application.Serializer = section.Serializer;
            cacheContainer.Application.Register = section.Register;
            cacheContainer.Application.RegisterAddress = section.RegisterAddress;
        }

        private void InitServiceMetadata()
        {
            Type[] types = ReflectionHelper.GetAssembly(section.ServiceDLL).GetTypes();

            foreach (Type type in types)
            {
                if (!type.IsInterface) continue;

                RpcServiceAttribute rpcServiceAttribute = (RpcServiceAttribute)type.GetCustomAttribute(typeof(RpcServiceAttribute), false);
                if (rpcServiceAttribute != null)
                {
                    RpcServiceMetadata serviceMetadata = new RpcServiceMetadata()
                    {
                        ServiceName = type.FullName,
                        ServiceType = type,
                        ServiceImplType = ReflectionHelper.GetServiceImplType(types, type)
                    };
                    //foreach (MethodInfo method in type.GetMembers())
                    //{
                    //    RpcMethodAttribute rpcMethodAttribute = (RpcMethodAttribute)method.GetCustomAttribute(typeof(RpcMethodAttribute), false);
                    //    if (rpcMethodAttribute != null)
                    //    {
                    //        serviceMetadatas.Add(method.Name, new RpcServiceMetadata
                    //        {
                    //            ServiceName = type.FullName,
                    //            ServiceType = type,
                    //            ServiceImplType = ReflectionHelper.GetServiceImplType(types, type)
                    //        });
                    //    }
                    //}

                    cacheContainer.ServiceMetadatas.Add(type.FullName, serviceMetadata);
                }
            }
        }

        private void InitServiceMethod()
        {

        }
    }
}
