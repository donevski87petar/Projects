using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        
    }
}
