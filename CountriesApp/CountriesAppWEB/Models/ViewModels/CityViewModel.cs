using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppWEB.Models.ViewModels
{
    public class CityViewModel
    {
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public City City { get; set; }


    }
}
