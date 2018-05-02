using StorageMaster.Contracts;
using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class StorageFactory : IStorageFactory
    {
        public Storage CreateStorage(string storageType, string storageName)
        {
            switch (storageType)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(storageName);
                case "DistributionCenter":
                    return new DistributionCenter(storageName);
                case "Warehouse":
                    return new Warehouse(storageName);
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }
        }
    }
}
