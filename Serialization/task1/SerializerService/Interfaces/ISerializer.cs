using SerializerService.Models;

namespace SerializerService.Interfaces
{
    public interface ISerializer
    {
        void Serialize(Department deparment);
        Department Deserialize();
    }
}