using OdeToFood.Domain.Models;
using OdeToFood.Domain.ViewModels;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICuisineRepository _cuisineRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        public AdminController(ICuisineRepository cuisineRepository,
                               IRestaurantRepository restaurantRepository,
                               IMenuItemRepository menuItemRepository)
        {
            _cuisineRepository = cuisineRepository;
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }

        #region Cuisine

        public ActionResult IndexCuisine()
        {
            var model = _cuisineRepository.GetCuisines();
            return View(model);
        }

        public ActionResult DetailsCuisine(int id)
        {
            var model = _cuisineRepository.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditCuisine(int id)
        {
            var model = _cuisineRepository.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                    //Add image logic
                    string fileName = Path.GetFileNameWithoutExtension(cuisine.ImageFile.FileName);
                    string extension = Path.GetExtension(cuisine.ImageFile.FileName);

                    //add date time now to make unique names always
                    fileName = DateTime.Now.ToString("yymmssfff") + extension;

                    cuisine.ImagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    //save in folder images
                    cuisine.ImageFile.SaveAs(fileName);

                _cuisineRepository.UpdateCuisine(cuisine);
                ModelState.Clear();
                return RedirectToAction("DetailsCuisine", new { id = cuisine.CuisineId });
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult CreateCuisine()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCuisine(Cuisine cuisine)
        {
            if (ModelState.IsValid)
            {
                //Add image logic
                string fileName = Path.GetFileNameWithoutExtension(cuisine.ImageFile.FileName);
                string extension = Path.GetExtension(cuisine.ImageFile.FileName);

                //add date time now to make unique names always
                fileName = DateTime.Now.ToString("yymmssfff") + extension;

                cuisine.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                //save in folder images
                cuisine.ImageFile.SaveAs(fileName);

                _cuisineRepository.CreateCuisine(cuisine);
                ModelState.Clear();
                return RedirectToAction("DetailsCuisine", new { id = cuisine.CuisineId });
            }
            return View(cuisine);
        }

        [HttpGet]
        public ActionResult DeleteCuisine(int id)
        {
            var model = _cuisineRepository.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCuisine(int id, Cuisine c)
        {
            var cuisine = _cuisineRepository.GetCuisine(id);
            _cuisineRepository.DeleteCuisine(cuisine);
            return RedirectToAction("IndexCuisine");
        }

        #endregion Cuisine


        #region Restaurant
        public ActionResult IndexRestaurant()
        {
            var model = _restaurantRepository.GetRestaurants();
            return View(model);
        }

        public ActionResult DetailsRestaurant(int id)
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

        public ActionResult CreateRestaurant()
        {
            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRestaurant(Restaurant restaurant)
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

                return RedirectToAction("DetailsRestaurant", "Admin", new { id = restaurant.RestaurantId });
            }

            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        public ActionResult EditRestaurant(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRestaurant(Restaurant restaurant)
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

                _restaurantRepository.UpdateRestaurant(restaurant);

                ModelState.Clear();

                return RedirectToAction("Details", "DetailsRestaurant", new { id = restaurant.RestaurantId });
            }
            var cuisines = _cuisineRepository.GetCuisines();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", restaurant.CuisineId);
            return View(restaurant);
        }

        public ActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost, ActionName("DeleteRestaurant")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurant(id);
            _restaurantRepository.DeleteRestaurant(restaurant);
            return RedirectToAction("IndexRestaurant");
        }

        #endregion Restaurant


        #region Menu Item

        public ActionResult DetailsMenuItem(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if(menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        public ActionResult CreateMenuItem()
        {
            var cuisines = _cuisineRepository.GetCuisines();
            var restaurants = _restaurantRepository.GetRestaurants();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName");
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMenuItem(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                //Add image logic
                string fileName = Path.GetFileNameWithoutExtension(menuItem.ImageFile.FileName);
                string extension = Path.GetExtension(menuItem.ImageFile.FileName);

                //add date time now to make unique names always
                fileName = DateTime.Now.ToString("yymmssfff") + extension;

                menuItem.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                //save in folder images
                menuItem.ImageFile.SaveAs(fileName);

                _menuItemRepository.CreateMenuItem(menuItem);
                ModelState.Clear();
                return RedirectToAction("Details", "MenuItems", new { id = menuItem.MenuItemId });
            }
            var cuisines = _cuisineRepository.GetCuisines();
            var restaurants = _restaurantRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }

        public ActionResult EditMenuItem(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }

            var cuisines = _cuisineRepository.GetCuisines();
            var subcategories = _restaurantRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMenuItem(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                //Add image logic
                string fileName = Path.GetFileNameWithoutExtension(menuItem.ImageFile.FileName);
                string extension = Path.GetExtension(menuItem.ImageFile.FileName);

                //add date time now to make unique names always
                fileName = DateTime.Now.ToString("yymmssfff") + extension;

                menuItem.ImagePath = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);

                //save in folder images
                menuItem.ImageFile.SaveAs(fileName);

                _menuItemRepository.UpdateMenuItem(menuItem);
                ModelState.Clear();
                return RedirectToAction("Details", "MenuItems", new { id = menuItem.MenuItemId });
            }

            var cuisines = _cuisineRepository.GetCuisines();
            var subcategories = _restaurantRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);

            return View(menuItem);
        }


        public ActionResult DeleteMenuItem(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        [HttpPost, ActionName("DeleteMenuItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMenuItemConfirmed(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            _menuItemRepository.DeleteMenuItem(menuItem);
            return RedirectToAction("Index");
        }

        #endregion
    }
}