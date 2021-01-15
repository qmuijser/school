using System;
using System.Collections.Generic;
using System.Text;

namespace api.Models
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
