using Product.ConsoleApp.Concrete;
using Product.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Product.ConsoleApp
{
    partial class Program
    {
        static readonly string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "product.dat");

        static void Main()
        {
        l1:
            try
            {
                Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            StorePartial store = new StorePartial();

            Center("Product Management System");
            Table("Look Categories and Products   --> 1");
            Table("Add Category                   --> 2");
            Table("Remove Category                --> 3");
            Table("Update Category                --> 4");
            Table("Add Product                    --> 5");
            Table("Remove Product                 --> 6");
            Table("Update Product                 --> 7");
            Table("Find Product                   --> 8");
            Choose("Please, choose number: ");

            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.Clear();
                    GetCategory(store);
                    break;
                case 2:
                    Console.Clear();
                    AddCategory(store);
                    break;
                case 3:
                    Console.Clear();
                    RemoveCategory(store);
                    break;
                case 4:
                    Console.Clear();
                    UpdateCategory(store);
                    break;
                case 5:
                    Console.Clear();
                    AddProduct(store);
                    break;
                case 6:
                    Console.Clear();
                    RemoveProduct(store);
                    break;
                case 7:
                    Console.Clear();
                    UpdateProduct(store);
                    break;
                case 8:
                    Console.Clear();
                    FindProduct(store);
                    break;

            }
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l1;
            }
        }

        private static void FindProduct(StorePartial store)
        {
        l2:    try
            {
                Center("Search Product");

                store.Load(path);

                var allProducts = store.GetAllProduct();

                int index = 1;

                Center("All Products");
                foreach (var item in allProducts)
                {
                    foreach (var element in item)
                    {
                        Table($"{index}. Product\n{element}");
                        index++;
                    }
                }

                Console.Write("Enter product name: ");
                string name = Console.ReadLine();
                var searching = store.FindProduct(name);

                foreach (var item in searching)
                {
                    Table(item);
                }

                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l2;
            }


        }

        private static void UpdateProduct(StorePartial store)
        {
        l3:    try
            {
                Center("Update Product");

                SortedCategory(store);
                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                int index = 1;
                int indexProduct = 1;
                foreach (var element in store)
                {
                    if (index == number)
                    {
                        if (element.Product.Lenght != 0)
                        {
                            foreach (var item in element)
                            {
                                Table($"{indexProduct}. Product\n{item}");
                                indexProduct++;
                            }
                        }
                        else
                        {
                            Error("There is not product... Click and go back!");
                            Console.ReadKey();
                            Main();
                        }

                    }
                    index++;

                }
                if (number > index - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }

                RelatedCategory temp = new RelatedCategory();

                Console.WriteLine("Please, enter product number: ");
                int pronum = Convert.ToInt32(Console.ReadLine());
                index = 1;
                int sequencenum = 1;
                int proID = 0;
                foreach (var element in store)
                {
                    if (sequencenum == number)
                    {
                        temp = element;
                        store.Remove(element);
                        foreach (Products item in element)
                        {

                            if (index == pronum)
                            {
                                proID = item.ProductID;
                                temp.Product.Remove(item);
                            }
                            index++;

                        }

                    }
                    sequencenum++;

                }
                if (pronum > index - 1 || pronum <= 0)
                {
                    Error("There is not this product... Click and go back");
                    Console.ReadKey();
                    Main();
                }

                Center("Enter Product:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Brand: ");
                string productBrand = Console.ReadLine();
                Console.Write("Product count: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Write("Product price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                temp.Product.Add(new Products(proID, productName, count, price, productBrand));

                store.Add(temp);
                store.Save(path);
                Success("GREAT! Process has been successfully completed!");
                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l3;
            }


        }

        private static void RemoveProduct(StorePartial store)
        {
        l4:    try
            {
                Center("Remove Product");

                SortedCategory(store);

                int index = 1;
                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                int categorynumber = 1;
                foreach (var element in store)
                {
                    if (categorynumber == number)
                    {
                        if (element.Product.Lenght != 0)
                        {
                            foreach (var item in element)
                            {
                                Choose($"{index}. Product \n{item}");
                                index++;
                            }

                        }
                        else
                        {
                            Error("There is not product... Click and go back!");
                            Console.ReadKey();
                            Main();
                        }


                    }
                    categorynumber++;

                }
                if (number > categorynumber - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }

                RelatedCategory temp = new RelatedCategory();

                Console.Write("Please, enter product number: ");
                int pronum = Convert.ToInt32(Console.ReadLine());
                index = 1;
                int sequencenum = 1;
                foreach (var element in store)
                {
                    if (sequencenum == number)
                    {
                        temp = element;
                        store.Remove(element);
                        foreach (Products item in element)
                        {

                            if (index == pronum)
                                temp.Product.Remove(item);
                            index++;
                        }

                    }
                    sequencenum++;

                }
                if (pronum > index - 1 || pronum <= 0)
                {
                    Error("There is not this product... Click and go back");
                    Console.ReadKey();
                    Main();
                }
                store.Add(temp);
                store.Save(path);

                Success("GREAT! Process has been successfully completed!");
                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l4;
            }



        }

        public static void SortedCategory(StorePartial store)
        {
            store.Load(path);

            var allCategories = store.GetAllCategory();

            List<Category> temp = new List<Category>();
            foreach (var item in allCategories)
            {
                if(item!=null)
                temp.Add(item);
            }

            
            int index = 1;
            foreach (var item in temp)
            {
                Choose($"{index}. Category\n{item}");
                index++;
            }
            if (store.Lenght == 0)
            {
                Error("There is not category... Click and go back");
                Console.ReadKey();
                Main();
            }
        }
        private static void AddProduct(StorePartial store)
        {
        l5:    try
            {
                Center("Add Product");
                RelatedCategory temp = new RelatedCategory();

                SortedCategory(store);

                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                int index = 1;
                foreach (var element in store)
                {
                    if (element.RelatedID != 0)
                    {

                        if (index == number)
                        {
                            temp = element;
                            store.Remove(element);

                        }
                        index++;
                    }

                }
                if (number > index - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }
                Center("Enter Product:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Brand: ");
                string productBrand = Console.ReadLine();
                Console.Write("Product count: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Write("Product price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                temp.Product.Add(new Products(store.AddProductID(), productName, count, price, productBrand));

                store.Add(temp);
                store.Save(path);
                Success("GREAT! Process has been successfully completed!");
                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l5;
            }



        }


        private static void UpdateCategory(StorePartial store)
        {
        l6:    try
            {
                Center("Update Category");

                SortedCategory(store);

                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                int index = 1;
                Console.Write("You want to change its name like: ");
                string name = Console.ReadLine();
                foreach (var element in store)
                {
                    if (index == number)
                    {
                        element.Categories.CategoryName = name;
                    }
                    index++;

                }
                if (number > index - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }
                store.Save(path);
                Success("GREAT! Process has been successfully completed!");
                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l6;
            }

        }

        private static void RemoveCategory(StorePartial store)
        {
         l7:   try
            {
                Center("Remove Category");

                SortedCategory(store);

                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                int index = 1;
                foreach (var element in store)
                {
                    if (index == number)
                    {
                        store.Remove(element);
                    }
                    index++;

                }
                if (number > index - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }

                store.Save(path);
                Success("GREAT! Process has been successfully completed!");
                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l7;
            }


        }

        private static void AddCategory(StorePartial store)
        {
        l8:
            try
            {
                Center("Add Category");
            store.Load(path);

            Console.Write("Category name: ");
            string name = Console.ReadLine();

            Store<Products> product = new Store<Products>();
            Category category = new Category(name);
            RelatedCategory rc = new RelatedCategory(category, product);

            rc.RelatedID = store.AddID();
            category.CategoryID = rc.RelatedID;

            store.Add(rc);

            store.Save(path);
            Success("GREAT! Process has been successfully completed!");
            Choose("Back : click enter");
            Console.ReadLine();
            Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l8;
            }
        }

        private static void GetCategory(StorePartial store)
        {
        l9:    try
            {
                Center("Get Category and it's products");

                SortedCategory(store);


                Console.Write("Please, enter category number: ");
                int number = Convert.ToInt32(Console.ReadLine());

                Center($"{number}. Category's Products");
                int index = 1;
                int indexProduct = 1;
                foreach (var element in store)
                {
                    if (index == number)
                    {
                        if (element.Product.Lenght != 0)
                        {
                            foreach (var item in element)
                            {
                                Table($"{indexProduct}. Product\n{item}");
                                indexProduct++;
                            }
                        }
                        else
                        {
                            Error("There is not product... Click and go back");
                            Console.ReadKey();
                            Main();
                        }
                    }
                    index++;

                }
                if (number > index - 1 || number <= 0)
                {
                    Error("There is not this category... Click and go back");
                    Console.ReadKey();
                    Main();
                }

                Choose("Back : click enter");
                Console.ReadLine();
                Main();
            }
            catch
            {
                Error("Please, click and try again...");
                Console.ReadKey();
                goto l9;
            }
        }

    }
}
