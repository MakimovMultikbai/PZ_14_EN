using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Facade
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product) => products.Add(product);
        public void RemoveProduct(Product product) => products.Remove(product);
        public List<Product> GetProducts() => new List<Product>(products);

        public void LoadProducts(List<Product> loadedProducts)
        {
            products = loadedProducts ?? new List<Product>();
        }
    }
}
