using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Order
    {
        public string OrderDetails { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<OrderDetail> ProductList { get; set; }
    }
}