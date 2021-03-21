
using Warehouse;

namespace Storage
{
    public class LimitedWarehouseWithMarkingAdapter : IStorage<IMarked>
    {
        LimitedWareHouseWithMarking storage;

        public LimitedWarehouseWithMarkingAdapter(LimitedWareHouseWithMarking warehouse) 
        {
            storage = warehouse;
        }
        public void Add(IMarked item)
        {
            storage.Push(item);
        }

        public bool Contains(IMarked item)
        {
            return storage.IsKeep(item);
        }

        public void Remove(IMarked item)
        {
            storage.Delete(item);
        }
    }
}
