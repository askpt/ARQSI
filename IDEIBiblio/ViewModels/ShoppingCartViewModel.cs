// ViewModel to show the contents of the shopping cart

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IDEIBiblio.Models;

namespace IDEIBiblio.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}