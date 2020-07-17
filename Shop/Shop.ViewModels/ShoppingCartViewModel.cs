using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShoppingCartItem> ShoppingCartItems {get;set;}
        public double ShoppingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}
