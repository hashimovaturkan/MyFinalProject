using System;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp.Infrastructure
{
    interface ICRUD<T>
    {
        void Add(T product);
        void Remove(T product);
        void Update(int index, T product);
    }
}
