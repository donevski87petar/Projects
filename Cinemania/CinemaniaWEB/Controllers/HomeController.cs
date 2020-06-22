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
using ReflectionIT.Mvc.Paging;
using CinemaniaWEB.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CinemaniaWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<CinemaniaIdentityUser> userManager;

        public HomeController(UserManager<CinemaniaIdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {

            CinemaniaIdentityUser user = userManager.GetUserAsync(HttpContext.User).Result;

            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<MovieDTO> allMovieList = JsonConvert.DeserializeObject<List<MovieDTO>>(stringData);

            HomeViewModel viewModel = new HomeViewModel
            {
                NewestMovies = allMovieList.OrderByDescending(m => m.ReleaseYear).Take(12),
                ActionMovies = allMovieList.Where(m => m.Genre.ToString() == "Action").Take(6),
                ThrillerMovies = allMovieList.Where(m => m.Genre.ToString() == "Thriller").Take(6),
                ComedyMovies = allMovieList.Where(m => m.Genre.ToString() == "Comedy").Take(6),
                CrimeMovies = allMovieList.Where(m => m.Genre.ToString() == "Crime").Take(6),
                HorrorMovies = allMovieList.Where(m => m.Genre.ToString() == "Horror").Take(6)
            };
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
