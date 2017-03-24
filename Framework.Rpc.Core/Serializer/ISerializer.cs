namespace Framework.Rpc.Core.Serializer
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T t);

        T Deserialize<T>(byte[] bytes);
    }
}