using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class ShopFacade
    {
        private readonly ProductService productService;
        private readonly CartService cartService;
        private readonly IDataStorageAdapter<Product> csvAdapter;
        private readonly IDataStorageAdapter<Product> xmlAdapter;

        public ShopFacade()
        {
            productService = new ProductService();
            cartService = new CartService();

            // Инициализируем адаптеры
            var csvSettings = new CsvAdapterSettings { HasHeaders = true };
            csvAdapter = new CsvAdapter<Product>(csvSettings);
            xmlAdapter = new XmlAdapter<Product>();
        }

        public List<Product> GetAllProducts() => productService.GetProducts();
        public List<Product> GetCartProducts() => cartService.GetCartProducts();

        public void AddProduct(Product product) => productService.AddProduct(product);
        public void AddToCart(Product product) => cartService.AddToCart(product);
        public void RemoveFromCart(Product product) => cartService.RemoveFromCart(product);

        // Методы для CSV
        public void SaveProductsToCsv(string filePath)
        {
            csvAdapter.Save(filePath, productService.GetProducts());
        }

        public void LoadProductsFromCsv(string filePath)
        {
            var products = csvAdapter.Load(filePath);
            productService.LoadProducts(products);
        }

        // Методы для XML
        public void SaveProductsToXml(string filePath)
        {
            xmlAdapter.Save(filePath, productService.GetProducts());
        }

        public void LoadProductsFromXml(string filePath)
        {
            var products = xmlAdapter.Load(filePath);
            productService.LoadProducts(products);
        }
    }
}
