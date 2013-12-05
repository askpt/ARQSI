using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Cart
    {
        public string CartDetails { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<CartDetail> ProductList { get; set; }
    }
}