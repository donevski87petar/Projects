using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaniaAPI.Models.DTO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CinemaniaWEB.Models;
using System.IO;

namespace CinemaniaWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<MovieDTO> movieList = JsonConvert.DeserializeObject<List<MovieDTO>>(stringData);
            var movieListOrdered = movieList.OrderBy(m => m.ReleaseYear).Reverse().Take(10);
            return View(movieListOrdered);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
