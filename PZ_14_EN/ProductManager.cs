using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PZ_14_EN
{
    internal class ProductManager
    {
        public List<Product>? products = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("products.json"));
        private int maxID;
        public ProductManager()
        {
            maxID = 1;
            foreach (Product p in products)
            {
                if (maxID < p._id) maxID = p._id;
            }
        }

        public void AddProduct(string name, string description, decimal price)
        {
            foreach (Product p in products) 
            {
                if (name == p._name) { return; }
            }
            maxID++;
            Product product = new Product(maxID, name, description, price);
            products.Add(product);
            File.WriteAllText("products.json", JsonSerializer.Serialize(products));
        }
        public void RemoveProduct(int id) 
        {
            if (GetProduct(id) != null)
            {
                products.Remove(GetProduct(id)!);
                File.WriteAllText("products.json", JsonSerializer.Serialize(products));
            }
        }

        public Product? GetProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product._id == id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
