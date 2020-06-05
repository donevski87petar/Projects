using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CinemaniaAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CinemaniaWEB.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<MovieDTO> movieList = JsonConvert.DeserializeObject<List<MovieDTO>>(stringData);

            return View(movieList);
        }

        [HttpGet]
        public IActionResult MovieDetails(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies/" + id.ToString()).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            MovieDTO movieDto = JsonConvert.DeserializeObject<MovieDTO>(stringData);
            return View(movieDto);
        }


        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddMovie(MovieDTO obj)
        {
            if (ModelState.IsValid)
            {
                //Image to bytes 
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    obj.Cover = p1;
                }

                //Post movie 
                string stringData = JsonConvert.SerializeObject(obj);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync("movies", contentData).Result;

                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return View(obj);
            }
        }


        [HttpGet]
        public IActionResult EditMovie(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies/" + id.ToString()).Result;
            var stringData = response.Content.ReadAsStringAsync().Result;
            MovieDTO movieDto = JsonConvert.DeserializeObject<MovieDTO>(stringData);
            return View(movieDto);
        }


        [HttpPost]
        public ActionResult EditMovie(MovieDTO movieDto)
        {
            if (ModelState.IsValid)
            {
                //Image to bytes 
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    movieDto.Cover = p1;
                }

                //Post movie 
                string stringData = JsonConvert.SerializeObject(movieDto);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsync("movies", contentData).Result;

                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return View(movieDto);
            }
        }


        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies/" + id.ToString()).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            MovieDTO movieDto = JsonConvert.DeserializeObject<MovieDTO>(stringData);
            return View(movieDto);
        }


        [HttpPost]
        public IActionResult DeleteMovie(MovieDTO movieDTO)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("movies/" + movieDTO.Id.ToString()).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            MovieDTO movieDto = JsonConvert.DeserializeObject<MovieDTO>(stringData);
            return RedirectToAction("Index", "Movies");
        }

    }
}