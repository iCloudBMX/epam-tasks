namespace SerializerService.Interfaces
{
    public interface ISerializer<T>
    {
        void Serialize(T source);
        T Deserialize();
    }
}