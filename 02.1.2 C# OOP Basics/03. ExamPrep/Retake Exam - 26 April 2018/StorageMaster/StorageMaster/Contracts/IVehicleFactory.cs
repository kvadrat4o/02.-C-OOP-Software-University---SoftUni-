using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Contracts
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string vehicleType);
    }
}
