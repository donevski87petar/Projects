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
            return RedirectToAction("Index");
        }

        #endregion Cuisine
    }
}