using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Domain.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cuisine> Cuisines { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
