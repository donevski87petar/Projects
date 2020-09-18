using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OdeToFood.Domain.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool isPromoted { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //Navigational properties
        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }
    }
}
