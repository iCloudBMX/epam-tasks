using System.IO;
using System.Xml.Serialization;
using SerializerService.Interfaces;
using SerializerService.Models;

namespace SerializerService.Serivces
{
    public class XMLSerializer : ISerializer<Department>
    {
        private string path;

        public XMLSerializer(string path)
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
                XmlSerializer xmlSerializer = 
                    new XmlSerializer(typeof(Department));

                xmlSerializer.Serialize(stream, department);
            }
        }

        public Department Deserialize()
        {       
            using(FileStream stream = new FileStream(
                path: this.path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                XmlSerializer xmlSerializer = 
                    new XmlSerializer(typeof(Department));

                return (Department) xmlSerializer.Deserialize(stream);
            }
        }
    }
}