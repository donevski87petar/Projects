using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Capital { get; set; }
        public string Region { get; set; }
        public double Area { get; set; }
        public double Population { get; set; }
        public byte[] Flag { get; set; }
    }
}
