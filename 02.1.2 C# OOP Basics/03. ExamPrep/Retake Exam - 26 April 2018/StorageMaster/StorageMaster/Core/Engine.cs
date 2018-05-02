using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        public void Run()
        {
            StorageMaster sm = new StorageMaster();
            var tokenInput = "";

            while ((tokenInput = Console.ReadLine()) != "END")
            {
                try
                {
                    var input = tokenInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string commandName = input[0];
                    switch (commandName)
                    {
                        case "AddProduct":
                            //AddProduct {type} {price}
                            string productType = input[1];
                            double productPrice = double.Parse(input[2]);
                            Console.WriteLine(sm.AddProduct(productType, productPrice));
                            break;
                        case "RegisterStorage":
                            //RegisterStorage {type} {name}
                            string storageType = input[1];
                            string storageName = input[2];
                            Console.WriteLine(sm.RegisterStorage(storageType, storageName));
                            break;
                        case "SelectVehicle":
                            //SelectVehicle {storageName} {garageSlot}
                            string storageN = input[1];
                            int garageSlot = int.Parse(input[2]);
                            Console.WriteLine(sm.SelectVehicle(storageN, garageSlot));
                            break;
                        case "LoadVehicle":
                            //LoadVehicle {productName1} {productName2} {productNameN}
                            List<string> productNames = input.Skip(1).ToList();
                            Console.WriteLine(sm.LoadVehicle(productNames));
                            break;
                        case "SendVehicleTo":
                            //SendVehicleTo {sourceName} {sourceGarageSlot} {destinationName}
                            string sourceName = input[1];
                            string destinationName = input[3];
                            int sourceGarageSlot = int.Parse(input[2]);
                            Console.WriteLine(sm.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                            break;
                        case "UnloadVehicle":
                            //UnloadVehicle {storageName} {garageSlot}
                            string storageNamee = input[1];
                            int garageSlot2 = int.Parse(input[2]);
                            Console.WriteLine(sm.UnloadVehicle(storageNamee, garageSlot2));
                            break;
                        case "GetStorageStatus":
                            //GetStorageStatus {storageName}
                            string storageNam = input[1];
                            Console.WriteLine(sm.GetStorageStatus(storageNam));
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            Console.WriteLine(sm.GetSummary());
            //if (tokenInput == "END")
            //{
            //    Console.WriteLine(sm.GetSummary());
            //}
        }
    }
}
