using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }
        //Set primary key (CategoryId to the table of Category) 
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        //Set primary key (CategoryId to the table of Category)

        [DisplayName("Subcategory")]
        public int SubcategoryId { get; set; }
        //Set primary key (SubcategoryId to the table of Subcategory) 
        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }
        //Set primary key (SubcategoryId to the table of Subcategory)

        [Range(1, int.MaxValue , ErrorMessage = "Price should be greater than 1")]
        public double Price { get; set; }
    }
}
