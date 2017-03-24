namespace Framework.Rpc.Core.Serializer
{
    public class SerializerFactory
    {
        public static ISerializer GetSerializer(SerializerType type)
        {
            switch (type)
            {
                case SerializerType.Binary:
                default:
                    return new BinarySerializer();
            }
        }
    }
}
