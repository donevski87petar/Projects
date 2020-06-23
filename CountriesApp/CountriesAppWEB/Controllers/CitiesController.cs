using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppWEB.Models;
using CountriesAppWEB.Models.ViewModels;
using CountriesAppWEB.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CountriesAppWEB.Controllers
{
    public class CitiesController : Controller
    {

        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        public CitiesController(ICountryRepository countryRepository , ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }



        public IActionResult Index()
        {
            return View(new City() { });
        }





        public async Task<IActionResult> GetAllCities()
        {
            return Json(new { data = await _cityRepository.GetAllAsync(SD.CitiesAPIPath) });
        }





        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<Country> countryList = await _countryRepository.GetAllAsync(SD.CountriesAPIPath);

            CityViewModel objVM = new CityViewModel()
            {
                CountryList = countryList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                City = new City()
            };


            if (id == null)
            {
                return View(objVM);
            }

            objVM.City = await _cityRepository.GetAsync(SD.CitiesAPIPath, id.GetValueOrDefault());
            if (objVM.City == null)
            {
                return NotFound();
            }
            return View(objVM);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CityViewModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.City.Id == 0)
                {
                    await _cityRepository.CreateAsync(SD.CitiesAPIPath, obj.City);
                }
                else
                {
                    await _cityRepository.UpdateAsync(SD.CitiesAPIPath + obj.City.Id, obj.City);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<Country> countryList = await _countryRepository.GetAllAsync(SD.CountriesAPIPath);

                CityViewModel objVM = new CityViewModel()
                {
                    CountryList = countryList.Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    City = obj.City
                };
                return View(objVM);
            }
        }





        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _cityRepository.DeleteAsync(SD.CitiesAPIPath, id);
            if (status)
            {
                return Json(new { success = true, message = "Delete Successful" });
            }
            return Json(new { success = false, message = "Delete Not Successful" });
        }




    }
}