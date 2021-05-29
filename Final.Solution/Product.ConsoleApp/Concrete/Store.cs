using Product.ConsoleApp.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Product.ConsoleApp.Concrete
{
    [Serializable]
    class Store<T> : ICRUD<T>, ISaved, IEnumerable<T>
    {
        
        T[] data = null;
        public int ID = 0;
        public int ProductID = 0;
        public int Lenght
        {
            get { 
                if(data != null)
                {
                    return data.Length;
                }
                else
                {
                    return 0;
                }
                
            }
            set { }
        }

        public Store()
        {
            data = new T[0];
        }
        public int AddID()
        {
            ID++;
            return ID;
        }

        public int AddProductID()
        {
            ProductID++;
            return ProductID;
        }

        public void Add(T product)
        {
            int leng = data.Length;
            Array.Resize(ref data, leng + 1);



            data[leng] = product;
        }

        public T[] GetAll()
        {
            return data;
        }

        

        public IEnumerator<T> GetEnumerator()
        {

            foreach (var element in data)
            {
                yield return element;
            }
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);
                if (fs.Length != 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    data = (T[])formatter.Deserialize(fs);
                    ID = (int)formatter.Deserialize(fs);
                    ProductID= (int)formatter.Deserialize(fs);
                }
                else
                {
                }
                

            }
        }

        public void Remove(T product)
        {
            int findIndex = Array.FindIndex(data, element => element.Equals(product));
            if (findIndex == -1)
            {
                throw new Exception("Your data can't be found!");
            }
            for (int i = findIndex + 1; i < data.Length; i++)
            {
                data[i - 1] = data[i];
            }

            Array.Resize(ref data, data.Length - 1);

        }

        public void Save(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, data);
                formatter.Serialize(fs, ID);
                formatter.Serialize(fs, ProductID);
            }
        }

        public void Update(int index, T product)
        {
            //int? id = products[index - 1].ID;
            //products[index - 1] = product;
            //products[index - 1].ID = id;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index >= data.Length)
                {
                    throw new Exception("Index was out of range.");
                }
                var product = data[index];
                return product;
            }
            set { }
        }
    }
}
