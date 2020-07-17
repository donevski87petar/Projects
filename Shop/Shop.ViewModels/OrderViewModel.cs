using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shop.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order placed")]
        public DateTime OrderPlacedTime { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Full Name")]
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
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [StringLength(10)]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
