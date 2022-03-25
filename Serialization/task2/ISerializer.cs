namespace task2
{
    public interface ISerializer<T>
    {
        void Serialize(T source);
        T Deserialize();
    }
}