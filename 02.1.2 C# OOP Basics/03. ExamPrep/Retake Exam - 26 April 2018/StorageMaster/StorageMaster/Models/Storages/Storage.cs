using StorageMaster.Contracts;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage : IStorage
    {
        private List<Vehicle> garage;

        private List<Product> products;

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool sFull => this.products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage.AsReadOnly();

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> garage)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = garage.ToList();
            this.products = new List<Product>();
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            //check how to get the vehicle form this slot ID
            Vehicle vehicle = this.garage[garageSlot];
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle  = this.GetVehicle(garageSlot);
            if (deliveryLocation.garage.Count == deliveryLocation.GarageSlots)
            {
                throw new InvalidOperationException("No room in garage!");
            }
            //if (!deliveryLocation.garage.Any(a => a != null))
            //{
            //    throw new InvalidOperationException("No room in garage!");
            //}
            //Vehicle vehicle = this.garage[garageSlot - 1];
            this.garage[garageSlot] = null;
            deliveryLocation.garage.Add(vehicle);
            int newGarageSlot = deliveryLocation.garage.Count(v => v != null);
            return newGarageSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            //if (this.garage.Count == this.GarageSlots)
            //{
            //    throw new InvalidOperationException("Storage is full!");
            //}
            if (this.garage.All(v => v != null))
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = this.GetVehicle(garageSlot);
            int productsUnloadedCount = 0;
            while (!vehicle.IsEmpty || !this.sFull)
            {
                foreach (var product in vehicle.Trunk)
                {
                    this.products.Add(product);
                    vehicle.RemoveProduct(product);
                    productsUnloadedCount++;
                }
            }
            return productsUnloadedCount;
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }
    }
}
