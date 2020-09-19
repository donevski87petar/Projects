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

        public MenuItemsController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
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

        
    }
}
