// ViewModel to display a confirmation information when user wants to remove an item

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public String Message { get; set; }
        public decimal CartTotal { get; set; }
        public int NumberOfItemsInCart { get; set; }
        public int NumberOfSelectedItem { get; set; }
        public int DeleteId { get; set; }
    }
}