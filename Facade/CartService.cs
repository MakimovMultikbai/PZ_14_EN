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

        public void LoadCart(List<Product> loadedCart)
        {
            cart = loadedCart ?? new List<Product>();
        }
    }
}
