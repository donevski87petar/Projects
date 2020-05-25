using AutoMapper;
using CountriesAppAPI.DTOs;
using CountriesAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAppAPI.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<City, CityCreateDTO>().ReverseMap();
            CreateMap<City, CityUpdateDTO>().ReverseMap();
        }
        
    }
}
