using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.DomainModels.Models;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }





        public IActionResult Index()
        {
            AppUser user = _userManager.GetUserAsync(HttpContext.User).Result;
            if(user != null)
            {
                TempData["WelcomeMessage"] = $"Welcome {user.UserName} !";
            }

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
