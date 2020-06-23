using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CountriesAppWEB.Models;
using CountriesAppWEB.Repository.IRepository;
using CountriesAppWEB.Models.ViewModels;
using X.PagedList;

namespace CountriesAppWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 5;

            var indexViewModel = new IndexViewModel()
            {
                CountryList = await _countryRepository.GetAllAsync(SD.CountriesAPIPath).Result.ToList().ToPagedListAsync(pageNumber, pageSize),
                CityList = await _cityRepository.GetAllAsync(SD.CitiesAPIPath).Result.ToList().ToPagedListAsync(pageNumber, pageSize)
            };
            return View(indexViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
