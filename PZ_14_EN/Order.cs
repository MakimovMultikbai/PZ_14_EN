using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_14_EN
{
    internal class Order
    {
        public int _id;
        private DateOnly _dateOrder;
        private decimal _total;
        public List<OrderElement> orderElements;

        public Order() 
        { 
            
        }
    }

    internal class OrderElement
    {
        private Product _product;
        public int _count { get; set; } = 1;
        private decimal _summ;
        public OrderElement(Product product, int count)
        {
            _product = product;
            _count = count;
            _summ = product._price * count;
        }

        public void ChangeCount(int count)
        {
            _count = count;
        }

    }
}
