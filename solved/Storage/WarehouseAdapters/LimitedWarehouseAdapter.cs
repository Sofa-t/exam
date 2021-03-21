using Warehouse;

namespace Storage
{
    public class LimitedWarehouseAdapter : IStorage<Product>        
    {
        LimitedWarehouse storage;
        

        public LimitedWarehouseAdapter(LimitedWarehouse warehouse)
        {
            storage = warehouse;
        }

        public void Add(Product item)
        {
            storage.Place(item);
        }

        public bool Contains(Product item)
        {
            return storage.IsHere(item);
        }

        public void Remove(Product item)
        {
            storage.Eliminate(item); 
        }
    }
}
