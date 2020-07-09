using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] Photo { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
