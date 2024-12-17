using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_14_EN
{
    internal class Product
    {
        public readonly int _id;
        public readonly string _name;
        public readonly string _description;
        public readonly decimal _price;
        public Product(int id, string name, string description, decimal price)
        {
            _id = id;
            _name = name;
            _description = description;
            _price = price;
        }
    }
}
