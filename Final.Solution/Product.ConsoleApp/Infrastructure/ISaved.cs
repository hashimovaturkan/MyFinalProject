using System;
using System.Collections.Generic;
using System.Text;

namespace Product.ConsoleApp.Infrastructure
{
    interface ISaved
    {
        void Save(string path);
        void Load(string path);
    }
}
