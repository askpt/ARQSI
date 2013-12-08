using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int NumberOfItems { get; set; }
        public decimal UnitaryPrice { get; set; }
        public virtual Book Book { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}