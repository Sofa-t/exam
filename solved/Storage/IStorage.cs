
namespace Storage
{
    public interface IStorage<in T>{
        void Add(T item);
        void Remove(T item);
        bool Contains(T item);
    }
}
