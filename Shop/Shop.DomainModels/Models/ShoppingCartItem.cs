using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int Qty { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [StringLength(255)]
        public string ShoppingCartId { get; set; }
    }
}
