using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_03.Restaurant
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubtotalProduct { get; set; }
        public Product(string productName, decimal productPrice,
            int productQuantity)
        {
            Name = productName;
            Price = productPrice;
            Quantity = productQuantity;
            SubtotalProduct = productQuantity * productPrice;
        }
    }
}
