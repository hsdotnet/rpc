using System;
using System.Reflection;

using Framework.Rpc.Core.ConfigSection;
using Framework.Rpc.Core.Provider.Domain;
using Framework.Rpc.Core.Helper;
using Framework.Rpc.Core.Provider.Attributes;
using Framework.Rpc.Core.Container;

namespace Framework.Rpc.Core.Provider
{
    public class LocalCacheService
    {
        private readonly ServerSection _section;

        private readonly ServerCacheContainer _cacheContainer;

        public LocalCacheService(ServerSection section, ServerCacheContainer cacheContainer)
        {
            _section = section;

            _cacheContainer = cacheContainer;
        }

        /// <summary>
        /// 缓存Service到本地
        /// </summary>
        public void CacheService()
        {
            InitApplication();

            InitServiceMetadata();
        }

        private void InitApplication()
        {
            _cacheContainer.Application.Name = _section.AppName;
            _cacheContainer.Application.Port = _section.Port;
            _cacheContainer.Application.Host = NetworkHelper.GetLocalIPAddress();
            _cacheContainer.Application.Time = 0;
            _cacheContainer.Application.Transport = _section.Transport;
            _cacheContainer.Application.Serializer = _section.Serializer;
            _cacheContainer.Application.Register = _section.Register;
            _cacheContainer.Application.RegisterAddress = _section.RegisterAddress;
        }

        private void InitServiceMetadata()
        {
            Type[] types = ReflectionHelper.GetAssembly(_section.ServiceDLL).GetTypes();

            foreach (Type type in types)
            {
                if (!type.IsInterface) continue;

                RpcServiceAttribute serviceAttribute = (RpcServiceAttribute)type.GetCustomAttribute(typeof(RpcServiceAttribute), false);
                if (serviceAttribute != null)
                {
                    ServiceMetadata serviceMetadata = new ServiceMetadata()
                    {
                        ServiceName = type.FullName,
                        ServiceType = type,
                        ServiceImplType = ReflectionHelper.GetServiceImplType(types, type),
                    };

                    foreach (MethodInfo method in type.GetMembers())
                    {
                        RpcMethodAttribute methodAttribute = (RpcMethodAttribute)method.GetCustomAttribute(typeof(RpcMethodAttribute), false);
                        if (methodAttribute != null)
                        {
                            MethodMetadata methodMetadata = new MethodMetadata()
                            {
                                MethodName = methodAttribute.MethodName,
                                Method = method
                            };

                            serviceMetadata.MethodMetadatas.Add(methodMetadata);
                        }
                    }

                    _cacheContainer.Application.ServiceMetadatas.Add(serviceMetadata);
                }
            }
        }
    }
}
