using System.Runtime.Serialization.Formatters.Binary;

namespace task3
{
    public static class ObjectCopierExtension
    {
        public static T Clone<T>(this T source)
        {
            if(typeof(T).GetType().IsSerializable)
            {
                using (Stream stream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter =
                        new BinaryFormatter();

                    binaryFormatter.Serialize(stream, source);
                    stream.Position = 0;
                    
                    return (T) binaryFormatter.Deserialize(stream);
                }            
            }

            return default;
        }
    }
}