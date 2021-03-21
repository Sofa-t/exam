
using Warehouse;
namespace Storage
{
    public class UnlimitedWarehouseWithMarkingAdapter : IStorage<IMarked>
    {
        private UnlimitedWarehouseWithMarking storage;
        public UnlimitedWarehouseWithMarkingAdapter(UnlimitedWarehouseWithMarking storage)
        {
            this.storage = storage;
        }
            
        public void Add(IMarked item)
        {
            storage.Put(item); 
        }

        public void Remove(IMarked item)
        {
            storage.Drop(item);  
        }

        public bool Contains(IMarked item)
        {
            return storage.IsKeep(item);
        }
    }
}