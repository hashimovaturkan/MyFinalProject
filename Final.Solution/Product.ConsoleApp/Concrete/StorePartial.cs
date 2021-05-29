using Product.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product.ConsoleApp.Concrete;

namespace Product.ConsoleApp.Concrete
{
    class StorePartial: Store<RelatedCategory>
    {
        public IEnumerable<Category> GetAllCategory()
        {
            
            foreach (var item in this.GetAll())
            {
                yield return item.Categories;
                
            }
        }

        public IEnumerable<Store<Products>> GetAllProduct()
        {
            foreach (var item in this.GetAll())
            {
                if(item.Product.Lenght !=0)
                yield return item.Product;

            }
        }
        public IEnumerable<Products> FindProduct(string name)
        {
            foreach (var item in this.GetAll())
            {

                if (item.Product.Lenght != 0)
                {
                    foreach (Products element in item)
                    {
                        if (element.ProductName == name)
                        {
                            yield return element;
                        }
                    }
                }



            }
        }
    }
}
