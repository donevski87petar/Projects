using Shop.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.DomainModels.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public ProductType ProductType { get; set; }
        public Brand Brand { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public List<ProductImage> Images { get; set; }
        public double Price { get; set; }

    }
}
