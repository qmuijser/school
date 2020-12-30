using System;
using System.Collections.Generic;
using System.Text;

namespace backend_school_api.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Total { get; set; }
        public string Adres { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderLine> OrderProducts { get; set; }
    }
}
