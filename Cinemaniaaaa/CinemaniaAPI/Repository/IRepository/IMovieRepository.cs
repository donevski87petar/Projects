using CinemaniaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Repository.IRepository
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int MovieId);
        bool MovieExists(string name);
        bool MovieExists(int id);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
