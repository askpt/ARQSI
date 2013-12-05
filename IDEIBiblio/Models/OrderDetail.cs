using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class OrderDetail
    {
        public IProduct Product { get; set; }
        public int NumberOfItems { get; set; }
        public Order Order { get; set; }
        public float PriceUn { get; set; }
    }
}