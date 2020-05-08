using ShoppingApp.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ShoppingApp.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [Required]
        public Cathegory Cathegory { get; set; }
        [Required]
        public ProductType ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        
        //added property
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }


}
