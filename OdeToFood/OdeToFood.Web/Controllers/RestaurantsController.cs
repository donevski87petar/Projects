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

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines , "CuisineId" , "CuisineName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                //Add image logic
                string fileName = Path.GetFileNameWithoutExtension(restaurant.ImageFile.FileName);
                string extension = Path.GetExtension(restaurant.ImageFile.FileName);

                //add date time now to make unique names always
                fileName = DateTime.Now.ToString("yymmssfff") + extension;

                restaurant.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                //save in folder images
                restaurant.ImageFile.SaveAs(fileName);

                _restaurantRepository.CreateRestaurant(restaurant);

                ModelState.Clear();

                return RedirectToAction("Details" , "Restaurants" , new { id = restaurant.RestaurantId});
            }

            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines , "CuisineId" , "CuisineName" , restaurant.CuisineId);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantId,RestaurantName,CuisineId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _restaurantRepository.UpdateRestaurant(restaurant);
                return RedirectToAction("Details" , "Restaurants" , new { id = restaurant.RestaurantId});
            }
            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            _restaurantRepository.DeleteRestaurant(restaurant);
            return RedirectToAction("Index");
        }
    }
}
