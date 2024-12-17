using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_14_EN
{
    internal class InternetShopFacade
    {
        private readonly ProductManager _productManager;
        private readonly List<Order> _orders;

        public InternetShopFacade()
        {
            _productManager = new ProductManager();
            _orders = new List<Order>();
        }

        // Методы для управления продуктами
        public void AddProduct(string name, string description, decimal price)
        {
            _productManager.AddProduct(name, description, price);
        }

        public void RemoveProduct(int id)
        {
            _productManager.RemoveProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productManager.products ?? new List<Product>();
        }

        // Методы для управления заказами
        public void CreateOrder()
        {
            var newOrder = new Order();
            _orders.Add(newOrder);
        }

        public void AddProductToOrder(int orderId, int productId, int count)
        {
            var order = _orders.FirstOrDefault(o => o._id == orderId);
            var product = _productManager.GetProduct(productId);

            if (order != null && product != null)
            {
                var orderElement = new OrderElement(product, count);
                if (order.orderElements == null)
                    order.orderElements = new List<OrderElement>();
                order.orderElements.Add(orderElement);
            }
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }
    }
}
