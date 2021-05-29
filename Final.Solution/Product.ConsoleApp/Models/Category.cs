using System;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp.Models
{
    [Serializable]
    class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
            
        }

        public override string ToString()
        {
            return $"Category ID: {CategoryID}\n" +
                $"Category Name: {CategoryName}\n";
        }

    }
}
