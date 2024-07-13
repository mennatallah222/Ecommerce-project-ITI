using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Item
    {
        public Item()
        {
        }

        public Item(Product product, int v)
        {
            Product = product;
        }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
