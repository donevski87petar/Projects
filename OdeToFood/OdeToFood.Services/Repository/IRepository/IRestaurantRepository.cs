using OdeToFood.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Services.Repository.IRepository
{
    public interface IRestaurantRepository
    {
        Restaurant CreateRestaurant(Restaurant restaurant);
        IEnumerable<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int restaurantId);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
    }
}
