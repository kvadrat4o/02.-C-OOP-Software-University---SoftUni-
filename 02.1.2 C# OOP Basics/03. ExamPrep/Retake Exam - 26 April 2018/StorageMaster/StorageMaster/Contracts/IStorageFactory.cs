using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Contracts
{
    public interface IStorageFactory
    {
        Storage CreateStorage(string storageType, string storageName);
    }
}
