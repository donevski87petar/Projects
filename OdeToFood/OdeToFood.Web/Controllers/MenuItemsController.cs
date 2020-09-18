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
using OdeToFood.Services.Repository.IRepository;

namespace OdeToFood.Web.Controllers
{
    public class MenuItemsController : Controller
    {
        private IMenuItemRepository _menuItemRepository;
        private ICuisineRepository _cuisineRepository;
        private IRestaurantRepository _subcategoryRepository;
        public MenuItemsController(IMenuItemRepository menuItemRepository,
                                   ICuisineRepository categoryRepository,
                                   IRestaurantRepository subcategoryRepository)
        {
            _menuItemRepository = menuItemRepository;
            _cuisineRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }

        // GET: MenuItems
        public ActionResult Index()
        {
            var menuItems = _menuItemRepository.GetMenuItems();
            return View(menuItems);
        }

        // GET: MenuItems/Details/5
        public ActionResult Details(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // GET: MenuItems/Create
        public ActionResult Create()
        {
            var cuisines = _cuisineRepository.GetCuisines();
            var restaurants = _subcategoryRepository.GetRestaurants();
            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName");
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName");
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItem menuItem)
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
                return RedirectToAction("Details" , "MenuItems" , new { id = menuItem.MenuItemId });
            }
            var cuisines = _cuisineRepository.GetCuisines();
            var restaurants = _subcategoryRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(restaurants, "RestaurantId", "RestaurantName", menuItem.RestaurantId);
            
            return View(menuItem);
        }

        // GET: MenuItems/Edit/5
        public ActionResult Edit(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }

            var cuisines = _cuisineRepository.GetCuisines();
            var subcategories = _subcategoryRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);
            
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuItemId,MenuItemName,Price,CuisineId,RestaurantId")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                _menuItemRepository.UpdateMenuItem(menuItem);
                return RedirectToAction("Details" , "MenuItems" , new { id = menuItem.MenuItemId});
            }

            var cuisines = _cuisineRepository.GetCuisines();
            var subcategories = _subcategoryRepository.GetRestaurants();

            ViewBag.CuisineId = new SelectList(cuisines, "CuisineId", "CuisineName", menuItem.CuisineId);
            ViewBag.RestaurantId = new SelectList(subcategories, "RestaurantId", "RestaurantName", menuItem.RestaurantId);
            
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public ActionResult Delete(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuItem = _menuItemRepository.GetMenuItem(id);
            _menuItemRepository.DeleteMenuItem(menuItem);
            return RedirectToAction("Index");
        }

    }
}
