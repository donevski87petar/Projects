using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICuisineRepository _cuisineRepository;
        private IRestaurantRepository _restaurantRepository;
        private IMenuItemRepository _menuItemRepository;

        public HomeController(ICuisineRepository cuisineRepository,
                              IRestaurantRepository restaurantRepository,
                              IMenuItemRepository menuItemRepository)
        {
            _cuisineRepository = cuisineRepository;
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Cuisines = _cuisineRepository.GetCuisines();
            homeViewModel.Restaurants = _restaurantRepository.GetRestaurants();
            homeViewModel.MenuItems = _menuItemRepository.GetMenuItems();
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}