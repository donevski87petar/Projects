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

namespace CinemaniaWEB.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {

            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies").Result;
            //string stringData = response.Content.ReadAsStringAsync().Result;
            //List<MovieDTO> movieList = JsonConvert.DeserializeObject<List<MovieDTO>>(stringData);


            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("movies").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            List<MovieDTO> allMovieList = JsonConvert.DeserializeObject<List<MovieDTO>>(stringData);

            HomeViewModel viewModel = new HomeViewModel
            {
                NewestMovies = allMovieList.OrderByDescending(m => m.ReleaseYear).Take(12),
                ActionMovies = allMovieList.Where(m => m.Genre.ToString() == "Action"),
                ThrillerMovies = allMovieList.Where(m => m.Genre.ToString() == "Thriller"),
                ComedyMovies = allMovieList.Where(m => m.Genre.ToString() == "Comedy"),
                CrimeMovies = allMovieList.Where(m => m.Genre.ToString() == "Crime"),
                HorrorMovies = allMovieList.Where(m => m.Genre.ToString() == "Horror")
            };

            //var movieListOrdered = movieList.OrderByDescending(m => m.ReleaseYear);
            //var moviesLast = movieListOrdered;//.Take(6);
            //return View(moviesLast);
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
