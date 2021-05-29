using Product.ConsoleApp.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp.Models
{
    [Serializable]
    class RelatedCategory: IEnumerable
    {
        public int RelatedID { get; set; }
        public Category Categories;
        public Store<Products> Product;

        public RelatedCategory(Category Category, Store<Products> Product)
        {
            this.Categories = Category;
            this.Product = Product;
        }
        public RelatedCategory()
        {

        }
        public RelatedCategory(Category Category)
        {
            this.Categories = Category;
        }
        
        public override string ToString()
        {
            return $"{Categories}\n" +
                $"{Product}\n";
        }

        public IEnumerator GetEnumerator()
        {
            if (Product != null)
            {
                foreach (var item in Product)
                {
                    yield return item;
                }
            }
            
        }
    }
}
