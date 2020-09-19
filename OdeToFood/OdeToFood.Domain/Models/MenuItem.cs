using OdeToFood.Domain.Enums;
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
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [Display(Name = "Menu Item")]
        public string MenuItemName { get; set; }
        [Display(Name = "Menu Item Type")]
        public MenuItemType MenuItemType { get; set; }
        public string Description { get; set; }
        [Display(Name = "Is Promoted?")]
        public bool isPromoted { get; set; }
        public double Price { get; set; }

        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //Navigational properties
        public int CuisineId { get; set; }
        public virtual Cuisine Cuisine { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
