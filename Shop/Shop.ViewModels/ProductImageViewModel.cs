using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.ViewModels
{
    public class ProductImageViewModel
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] Photo { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
