using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Framework.Rpc.Core.Helper
{
    public class ReflectionHelper
    {
        public static string GetServerPath()
        {
            string path = AppDomain.CurrentDomain.RelativeSearchPath;
            if (string.IsNullOrEmpty(path))
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
            }
            if (!path.EndsWith("\\"))
            {
                path += "\\";
            }
            return path;
        }

        public static Assembly GetAssembly(string dll)
        {
            string path = GetServerPath();
            byte[] buffer = File.ReadAllBytes(string.Concat(path, dll));
            return Assembly.Load(buffer);
        }

        public static Type GetServiceImplType(Type[] types, Type serviceType)
        {
            foreach (Type type in types)
            {
                if (type.IsInterface) continue;

                Type[] interfaces = type.GetInterfaces();

                if (interfaces.Any(t => t == serviceType))
                {
                    return type;
                }
            }
            return null;
        }
    }
}