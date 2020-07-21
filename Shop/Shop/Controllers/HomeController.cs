using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.Models;
using Shop.ViewModels;
using X.PagedList;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, 
                              UserManager<AppUser> userManager,
                              IProductRepository productRepository,
                              IShoppingCartRepository shoppingCart,
                              IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
    }


        public IActionResult Index(int? page, string searchTerm = null)
        {
            AppUser user = _userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.queryString = HttpContext.Request.Query["searchTerm"];
            if (user != null)
            {
                TempData["WelcomeMessage"] = $"You are logged in as {user.UserName} !";
            }

            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

            var pageNumber = page ?? 1;
            int pageSize = 8;

            if (string.IsNullOrEmpty(searchTerm))
            {
                var modelList = _productRepository.GetAll();
                var viewModelList = new List<HomeViewModel>();
                foreach (var item in modelList)
                {
                    viewModelList.Add(_mapper.Map<HomeViewModel>(item));
                }

                var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
                return View(viewModelPagedList);
            }
            else
            {
                var modelList = _productRepository.GetAll().Where(p =>
                    p.ModelName.ToLower().Contains(searchTerm.ToLower()) ||
                    p.Brand.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                    p.Category.ToString().ToLower().Contains(searchTerm.ToLower()) ||
                    p.ProductType.ToString().ToLower().Contains(searchTerm.ToLower()));
                
                var viewModelList = new List<HomeViewModel>();
                foreach (var item in modelList)
                {
                    viewModelList.Add(_mapper.Map<HomeViewModel>(item));
                }

                var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
                return View(viewModelPagedList);
            }


        }


        //public IActionResult Index(int? page , string searchTerm)
        //{
        //    AppUser user = _userManager.GetUserAsync(HttpContext.User).Result;
        //    if(user != null)
        //    {
        //        TempData["WelcomeMessage"] = $"You are logged in as {user.UserName} !";
        //    }

        //    ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

        //    var pageNumber = page ?? 1;
        //    int pageSize = 8;

        //    var modelList = _productRepository.GetAll();
        //    var viewModelList = new List<HomeViewModel>();
        //    foreach (var item in modelList)
        //    {
        //        viewModelList.Add(_mapper.Map<HomeViewModel>(item));
        //    }

        //    var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
        //    return View(viewModelPagedList);
        //}

        public IActionResult ProductDetails(int id)
        {
            Product product = _productRepository.GetById(id);
            HomeViewModel productHomeViewModel = _mapper.Map<HomeViewModel>(product);
            if (productHomeViewModel == null)
            {
                return View("Error");
            }
            return View(productHomeViewModel);
        }

        public IActionResult ContactUs()
        {
            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
