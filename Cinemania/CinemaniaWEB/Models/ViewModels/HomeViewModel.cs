using CinemaniaAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaWEB.Models
{
    public class HomeViewModel
    {
        public IEnumerable<MovieDTO> NewestMovies { get; set; }
        public IEnumerable<MovieDTO> ActionMovies { get; set; }
        public IEnumerable<MovieDTO> ThrillerMovies { get; set; }
        public IEnumerable<MovieDTO> ComedyMovies { get; set; }
        public IEnumerable<MovieDTO> CrimeMovies { get; set; }
        public IEnumerable<MovieDTO> HorrorMovies { get; set; }
    }
}
