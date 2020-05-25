using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.DTOs
{
    public class CityCreateDTO
    {
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
