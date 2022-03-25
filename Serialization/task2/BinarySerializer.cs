using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace task2
{
    public class BinarySerializer : ISerializer<Person>
    {
        private string path;

        public BinarySerializer(string path)
        {
            this.path = path;
        }
        
        public void Serialize(Person person)
        {
            using(FileStream stream = new FileStream(
                path: this.path, 
                mode: FileMode.Create,
                access: FileAccess.Write))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, person);
            }
        }

        public Person Deserialize()
        {
            using(FileStream stream = new FileStream(
                path: this.path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                return (Person) binaryFormatter.Deserialize(stream);
            }
        }
    }
}