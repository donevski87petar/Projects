using CinemaniaAPI.Data;
using CinemaniaAPI.Models;
using CinemaniaAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaniaAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }



        public bool CreateMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
            return Save();
        }

        public Movie GetMovie(int MovieId)
        {
            return _db.Movies.FirstOrDefault(m => m.Id == MovieId);
        }

        public ICollection<Movie> GetMovies()
        {
            return _db.Movies.OrderBy(m => m.Title).ToList();
        }


        public bool MovieExists(string name)
        {
            bool value = _db.Movies.Any(a => a.Title.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool MovieExists(int id)
        {
            return _db.Movies.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            _db.Movies.Update(movie);
            return Save();
        }
    }
}
