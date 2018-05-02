using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Contracts
{
    public interface IProductFactory
    {
        Product CreateProduct(string productType, double productPrice);
    }
}
