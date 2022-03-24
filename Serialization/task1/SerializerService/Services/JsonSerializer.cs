using Newtonsoft.Json;
using SerializerService.Interfaces;
using SerializerService.Models;

namespace SerializerService.Serivces
{
    public class JsonSerializer : ISerializer
    {
        private string path;

        public JsonSerializer(string path)
        {
            this.path = path;
        }

        public void Serialize(Department department)
        {
            string serializedDepartment = JsonConvert.SerializeObject(department);

            File.WriteAllText(this.path, serializedDepartment);
        }

        public Department Deserialize()
        {
            string serializedDepartment = File.ReadAllText(this.path);

            return JsonConvert.DeserializeObject<Department>(serializedDepartment);
        }
    }
}