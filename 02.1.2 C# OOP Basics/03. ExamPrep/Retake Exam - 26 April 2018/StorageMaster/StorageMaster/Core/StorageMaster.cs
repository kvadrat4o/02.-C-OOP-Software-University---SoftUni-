using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Storage> storageRegistry;

        private List<Product> productsPool;

        private ProductFactory productFactory;

        private StorageFactory storageFactory;

        private VehicleFactory vehicleFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.storageRegistry = new List<Storage>();
            this.productsPool = new List<Product>();

            this.vehicleFactory = new VehicleFactory();
            this.storageFactory = new StorageFactory();
            this.productFactory = new ProductFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            this.productsPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            Vehicle tempVehicle = storage.GetVehicle(garageSlot);
            this.currentVehicle = tempVehicle;
            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int countOfLoadedProducts = 0;
            foreach (var product in productNames)
            {
                if (!this.productsPool.Any(p => p.GetType().Name == product))
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }
                if (this.currentVehicle.IsFull)
                {
                    this.currentVehicle.RemoveProduct(this.currentVehicle.Trunk.Last());
                }
                Product pr = this.productsPool.Last(p => p.GetType().Name == product);
                this.productsPool.Remove(pr);
                this.currentVehicle.LoadProduct(pr);
                countOfLoadedProducts++;
            }
            return $"Loaded {countOfLoadedProducts}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!this.storageRegistry.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            Storage destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            int firstEmptySlot = (destinationStorage.Garage.Count());
            sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {firstEmptySlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            int unloadedProductsCount = 0;
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            Vehicle vehicle = sourceStorage.GetVehicle(garageSlot);
            int initialProductsCount = vehicle.Trunk.Count;
            while (vehicle.Trunk.Count > 0)
            {
                Product product = vehicle.Unload();
                this.productsPool.Add(product);
                sourceStorage.AddProduct(product);
                unloadedProductsCount++;
            }
            return $"Unloaded {unloadedProductsCount}/{initialProductsCount} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder sb = new StringBuilder();
            Storage sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            var grouppedProducts = sourceStorage.Products.GroupBy(grp => grp.GetType().Name)
                .OrderByDescending(gr => gr.Count()).Select(p => p).ToList();
            double totalProductWeights = sourceStorage.Products.Sum(a => a.Weight);
            sb.Append($"Stock ({totalProductWeights}/{sourceStorage.Capacity}): [");
            List<string> appendedProducts = new List<string>();
            foreach (var product in grouppedProducts)
            {
                appendedProducts.Add(($"{product.Key} ({product.Count()})"));
            }
            sb.Append(string.Join(", ", appendedProducts));
            sb.AppendLine("]");
            sb.Append("Garage: [");
            for (int i = 0; i < sourceStorage.Garage.Count; i++)
            {
                sb.Append($"{sourceStorage.GetVehicle(i).GetType().Name}");
                sb.Append("|");
            }
            int emptySlotsCount = sourceStorage.GarageSlots - sourceStorage.Garage.Count;
            for (int i = 0; i < emptySlotsCount; i++)
            {
                sb.Append("empty");
                if (i == emptySlotsCount - 1)
                {
                    continue;
                }
                else
                {
                    sb.Append("|");
                }
            }
            sb.Append("]");
            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();
            //this.storageRegistry = this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Weight)).ToList();
            foreach (var storage in this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                double totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
