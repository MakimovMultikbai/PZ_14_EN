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

        public void SaveToCsv(string filePath)
        {
            File.WriteAllLines(filePath, products.Select(p => p.Name));
        }

        public void LoadFromCsv(string filePath)
        {
            if (File.Exists(filePath))
            {
                products = File.ReadAllLines(filePath).Select(name => new Product { Name = name }).ToList();
            }
        }

        public void SaveToXml(string filePath)
        {
            using var writer = new StreamWriter(filePath);
            new XmlSerializer(typeof(List<Product>)).Serialize(writer, products);
        }

        public void LoadFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(filePath);
                products = (List<Product>)new XmlSerializer(typeof(List<Product>)).Deserialize(reader);
            }
        }
    }
}
