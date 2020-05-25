using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppWEB.Models;
using CountriesAppWEB.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAppWEB.Controllers
{
    public class CountriesController : Controller
    {

        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }



        public IActionResult Index()
        {
            return View(new Country() { });
        }


        public async Task<IActionResult> GetAllCountries()
        {
            return Json(new { data = await _countryRepository.GetAllAsync(SD.CountriesAPIPath) });
        }
    }
}