using System.Reflection;

namespace Framework.Rpc.Core.Provider.Domain
{
    public class MethodMetadata
    {
        public string MethodName { get; set; }

        public MethodInfo Method { get; set; }
    }
}