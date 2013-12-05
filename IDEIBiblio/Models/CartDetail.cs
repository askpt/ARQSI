using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class CartDetail
    {
        public IProduct Product { get; set; }
        public Cart Cart { get; set; }
        public int NumberOfItems { get; set; }
        public float PriceUn { get; set; }
    }
}