using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Facade
{
    public class CartService
    {
        private List<Product> cart = new List<Product>();

        public void AddToCart(Product product) => cart.Add(product);
        public void RemoveFromCart(Product product) => cart.Remove(product);
        public List<Product> GetCartProducts() => new List<Product>(cart);

        public bool PlaceOrder()
        {
            if (cart.Count > 0)
            {
                cart.Clear();
                return true;
            }
            return false;
        }

        public void SaveToCsv(string filePath)
        {
            File.WriteAllLines(filePath, cart.Select(p => p.Name));
        }

        public void LoadFromCsv(string filePath)
        {
            if (File.Exists(filePath))
            {
                cart = File.ReadAllLines(filePath).Select(name => new Product { Name = name }).ToList();
            }
        }

        public void SaveToXml(string filePath)
        {
            using var writer = new StreamWriter(filePath);
            new XmlSerializer(typeof(List<Product>)).Serialize(writer, cart);
        }

        public void LoadFromXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(filePath);
                cart = (List<Product>)new XmlSerializer(typeof(List<Product>)).Deserialize(reader);
            }
        }
    }
}
