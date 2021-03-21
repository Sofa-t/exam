
using Warehouse;
namespace Storage
{
    public class UnlimitedWarehouseAdapter : IStorage<Product>
    {
        private UnlimitedWarehouse storage;

        public UnlimitedWarehouseAdapter(UnlimitedWarehouse storage)
        {
            this.storage = storage;
        }

        public void Add(Product item)
        {
            storage.ThrowIn(item); 
        }

        public void Remove(Product item)
        {
            storage.Utilize(item); 
        }

        public bool Contains(Product item)
        {
            return storage.IsIn(item);
        }
    }
}