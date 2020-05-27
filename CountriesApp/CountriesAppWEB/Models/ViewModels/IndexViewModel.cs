using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppWEB.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Country> CountryList { get; set; }
        public IEnumerable<City> CityList { get; set; }

    }
}
