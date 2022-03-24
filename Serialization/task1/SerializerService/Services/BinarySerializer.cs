using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SerializerService.Interfaces;
using SerializerService.Models;

namespace SerializerService.Serivces
{
    public class BinarySerializer : ISerializer
    {
        private string path;

        public BinarySerializer(string path)
        {
            this.path = path;
        }

        public void Serialize(Department department)
        {
            using(FileStream stream = new FileStream(
                path: this.path, 
                mode: FileMode.Create,
                access: FileAccess.Write))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, department);
            }
        }

        public Department Deserialize()
        {
            using(FileStream stream = new FileStream(
                path: this.path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                return (Department) binaryFormatter.Deserialize(stream);
            }
        }
    }
}