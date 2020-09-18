using OdeToFood.Data;
using OdeToFood.Domain.Models;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Repository
{
    public class CuisineRepository : ICuisineRepository
    {
        private ApplicationDbContext _db;
        public CuisineRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Cuisine> GetCuisines()
        {
            return _db.Cuisines.Include(r => r.Restaurants).ToList()
                               .OrderBy(c => c.CuisineName);
        }

        public Cuisine GetCuisine(int cuisineId)
        {
            return _db.Cuisines.Include(r => r.Restaurants)
                       .FirstOrDefault(r => r.CuisineId == cuisineId);
        }

        public Cuisine CreateCuisine(Cuisine cuisine)
        {
            _db.Cuisines.Add(cuisine);
            _db.SaveChanges();
            return cuisine;
        }

        public void DeleteCuisine(Cuisine cuisine)
        {
            _db.Cuisines.Remove(cuisine);
            _db.SaveChanges();
        }

        public void UpdateCuisine(Cuisine cuisine)
        {
            var entry = _db.Entry(cuisine);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
