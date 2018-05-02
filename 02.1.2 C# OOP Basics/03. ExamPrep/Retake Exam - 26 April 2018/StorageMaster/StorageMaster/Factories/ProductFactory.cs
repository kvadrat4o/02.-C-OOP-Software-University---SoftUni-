using StorageMaster.Contracts;
using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(string productType, double productPrice)
        {
            //double price = double.Parse(productPrice);
            if (productType == "Gpu")
            {
                Product product = new Gpu(productPrice);
                return product;
            }
            else if (productType == "Ram")
            {
                Product product = new Ram(productPrice);
                return product;
            }
            else if (productType == "SolidStateDrive")
            {
                Product product = new SolidStateDrive(productPrice);
                return product;
            }
            else if (productType == "HardDrive")
            {
                Product product = new HardDrive(productPrice);
                return product;
            }
            else
            {
                throw new InvalidOperationException($"Invalid product type!");
            }
            
        }
    }
}
