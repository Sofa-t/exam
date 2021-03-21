using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storage;
using Warehouse;

namespace StorageUnitTestProject
{
    [TestClass]
    public class StorageUnitTests
    {
        MarkedProduct productA = new MarkedProduct("A", new Size(4, 5, 6), 2.1, 9785922100205);
        Product productB = new Product("B", new Size(1, 2, 3), 1.5);
        
        LimitedWarehouse storageLW = new LimitedWarehouse(5);
        LimitedWareHouseWithMarking storageLWM = new LimitedWareHouseWithMarking(8);
        UnlimitedWarehouse storageUW = new UnlimitedWarehouse();
        UnlimitedWarehouseWithMarking storageUWM = new UnlimitedWarehouseWithMarking();

        [TestMethod]
        public void LimitedWarehouseTest() 
        {
            var storage = new LimitedWarehouseAdapter(storageLW);

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        [TestMethod]
        public void UnlimitedWarhouseTest()
        {
            var storage = new UnlimitedWarehouseAdapter(storageUW);            

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        [TestMethod]
        public void LimitedWareHouseWithMarkingTest()
        {
            var storage = new LimitedWarehouseWithMarkingAdapter(storageLWM);            

            AssertStorageAddDelete(storage, productA);
            if (productB is IMarked marked)
                AssertStorageAddDelete(storage, marked);
        }

        [TestMethod]
        public void UnlimitedWarehouseWithMarkingTest()
        {
            var storage = new UnlimitedWarehouseWithMarkingAdapter(storageUWM);

            AssertStorageAddDelete(storage, productA);
            if (productB is IMarked marked)
                AssertStorageAddDelete(storage, marked);
        }
        
        private void AssertStorageAddDelete(UnlimitedWarehouseWithMarkingAdapter storage, IMarked item)            
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
        
        void AssertStorageAddDelete(IStorage<Product> storage, Product item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
        
        private void AssertStorageAddDelete(LimitedWarehouseWithMarkingAdapter storage, IMarked item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item));

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
    }
}