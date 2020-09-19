using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data;
using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Services.Repository.IRepository;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ICuisineRepository _cuisineRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository,
                                       ICuisineRepository cuisineRepository,
                                       IMenuItemRepository menuItemRepository)
        {
            _restaurantRepository = restaurantRepository;
            _cuisineRepository = cuisineRepository;
            _menuItemRepository = menuItemRepository;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetRestaurants();
            return View(restaurants);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            IEnumerable<MenuItem> menuItems = _menuItemRepository.GetMenuItems()
                                                   .Where(r => r.RestaurantId == id);

            RestaurantDetailsViewModel restaurantDetailsVM = new RestaurantDetailsViewModel();
            restaurantDetailsVM.Restaurant = restaurant;
            restaurantDetailsVM.MenuItems = menuItems;
            
            return View(restaurantDetailsVM);
        }

        
    }
}
