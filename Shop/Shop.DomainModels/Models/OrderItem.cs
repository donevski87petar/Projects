using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
