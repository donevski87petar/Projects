using OdeToFood.Domain.Models;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class CuisinesController : Controller
    {
        private ICuisineRepository _cuisineRepository;
        public CuisinesController(ICuisineRepository cuisineRepository)
        {
            _cuisineRepository = cuisineRepository;
        }

        public ActionResult Index()
        {
            var model = _cuisineRepository.GetCuisines();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _cuisineRepository.GetCuisine(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


    }
}