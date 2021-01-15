using System;
using System.Collections.Generic;
using System.Text;

namespace api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
