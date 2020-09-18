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
    public class RestaurantRepository : IRestaurantRepository
    {
        private ApplicationDbContext _db;
        public RestaurantRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _db.Restaurants.Include(c => c.Cuisine).ToList().OrderBy(r => r.RestaurantName);
        }

        public Restaurant GetRestaurant(int restaurantId)
        {
            return _db.Restaurants.Include(c => c.Cuisine).FirstOrDefault(s => s.RestaurantId == restaurantId);
        }

        public Restaurant CreateRestaurant(Restaurant restaurant)
        {
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
            return restaurant;
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var entry = _db.Entry(restaurant);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
