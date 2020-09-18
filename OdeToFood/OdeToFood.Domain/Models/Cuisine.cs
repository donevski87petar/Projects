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
    public class Cuisine
    {
        public int CuisineId { get; set; }
        [Required]
        [Display (Name = "Cuisine")]
        public string CuisineName { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //Navigational properties
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<MenuItem> Menuitem { get; set; }
    }
}
