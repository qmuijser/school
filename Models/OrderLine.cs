using System;
using System.Collections.Generic;
using System.Text;

namespace backend_school_api.Models
{
    public class OrderLine
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
