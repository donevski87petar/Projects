using AutoMapper;
using CinemaniaAPI.Models;
using CinemaniaAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Mapper
{
    public class MovieMappings : Profile
    {
        public MovieMappings()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
