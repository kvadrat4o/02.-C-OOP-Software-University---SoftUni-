using StorageMaster.Contracts;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType)
        {
            if (vehicleType == "Van")
            {
                return new Van();
            }
            else if (vehicleType == "Truck")
            {
                return new Truck();
            }
            else if (vehicleType == "Semi")
            {
                return new Semi();
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }
        }
    }
}
