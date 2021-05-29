using Product.ConsoleApp.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp.Models
{
    [Serializable]
    class Products 
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Products()
        {

        }
        public Products(int ProductID, string ProductName, int Count, double Price, string ProductBrand)
        {
            this.ProductID = ProductID;
            this.Count = Count;
            this.ProductName = ProductName;
            this.Price = Price;
            this.ProductBrand = ProductBrand;
        }


        public override string ToString()
        {
            return $"Product ID: {ProductID}\n" +
                $"Product Name: {ProductName}\n" +
                $"Product Brand: {ProductBrand}\n" +
                $"Product Count: {Count}\n" +
                $"Product Price: {Price}\n";
        }

    }
}
