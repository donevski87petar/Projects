using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderPlacedTime { get; set; }

        [StringLength(255)]
        [Required]
        public string FullName { get; set; }

        [StringLength(255)]
        [Required]
        public string Address { get; set; }

        [StringLength(255)]
        [Required]
        public string City { get; set; }

        [StringLength(255)]
        [Required]
        public string Country { get; set; }

        [StringLength(6)]
        [Required]
        public string ZipCode { get; set; }

        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        public double OrderTotal { get; set; }

        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        [ForeignKey("OrderDetail")]
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
