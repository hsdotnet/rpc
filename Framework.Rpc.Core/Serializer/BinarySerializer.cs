using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.Rpc.Core.Serializer
{
    public class BinarySerializer : ISerializer
    {
        public byte[] Serialize<T>(T t)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(ms, t);

                ms.Position = 0;

                byte[] read = new byte[ms.Length];

                ms.Read(read, 0, read.Length);

                return read;
            }
        }

        public T Deserialize<T>(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                ms.Position = 0;

                BinaryFormatter formatter = new BinaryFormatter();

                T t = (T)formatter.Deserialize(ms);

                return t;
            }
        }
    }
}
