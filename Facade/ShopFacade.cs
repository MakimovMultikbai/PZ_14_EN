using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ShopFacade
    {
        private ProductService productService;
        private CartService cartService;

        public ShopFacade()
        {
            productService = new ProductService();
            cartService = new CartService();
        }

        public void AddProduct(Product product) => productService.AddProduct(product);
        public void RemoveProduct(Product product) => productService.RemoveProduct(product);
        public List<Product> GetAllProducts() => productService.GetProducts();

        public void AddToCart(Product product) => cartService.AddToCart(product);
        public void RemoveFromCart(Product product) => cartService.RemoveFromCart(product);
        public List<Product> GetCartProducts() => cartService.GetCartProducts();

        public bool PlaceOrder() => cartService.PlaceOrder();

        public void SaveToCsv()
        {
            productService.SaveToCsv("products.csv");
            cartService.SaveToCsv("orders.csv");
        }

        public void LoadFromCsv()
        {
            productService.LoadFromCsv("products.csv");
            cartService.LoadFromCsv("orders.csv");
        }

        public void SaveToXml()
        {
            productService.SaveToXml("products.xml");
            cartService.SaveToXml("orders.xml");
        }

        public void LoadFromXml()
        {
            productService.LoadFromXml("products.xml");
            cartService.LoadFromXml("orders.xml");
        }
    }
}
