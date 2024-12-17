using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{Price}";
        }

        public static Product FromCsv(string csvLine)
        {
            var values = csvLine.Split(',');
            return new Product
            {
                Id = int.Parse(values[0]),
                Name = values[1],
                Price = decimal.Parse(values[2])
            };
        }
    }
}
