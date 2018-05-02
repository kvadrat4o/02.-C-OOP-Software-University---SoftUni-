using StorageMaster.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public abstract class Product : IProduct
    {
        private double price;

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public virtual double Weight { get; }

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
