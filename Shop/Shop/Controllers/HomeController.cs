using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Enums;
using Shop.DomainModels.Models;
using Shop.Models;
using Shop.Services;
using Shop.ViewModels;
using X.PagedList;
using Microsoft.Extensions.Configuration;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCart;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, 
                              UserManager<AppUser> userManager,
                              IProductRepository productRepository,
                              IShoppingCartRepository shoppingCart,
                              IMapper mapper,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
            _configuration = configuration;
    }



        public IActionResult Index(int? page, string productType = null, string category = null, string searchTerm = null)
        {
            AppUser user = _userManager.GetUserAsync(HttpContext.User).Result;
            ViewBag.productType = HttpContext.Request.Query["productType"];
            ViewBag.category = HttpContext.Request.Query["category"];
            ViewBag.searchTerm = HttpContext.Request.Query["searchTerm"];

            if (user != null)
            {
                TempData["WelcomeMessage"] = $"You are logged in as {user.UserName}";
            }

            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

            var pageNumber = page ?? 1;
            int pageSize = 9;

            if (string.IsNullOrEmpty(searchTerm))
            {
                if(productType == null && category == null)
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
                    if(category != null && productType != null)
                    {
                        var modelList = _productRepository.GetAll()
                            .Where(p => p.ProductType.ToString() == productType && p.Category.ToString() == category);
                        var viewModelList = new List<HomeViewModel>();
                        foreach (var item in modelList)
                        {
                            viewModelList.Add(_mapper.Map<HomeViewModel>(item));
                        }

                        var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
                        return View(viewModelPagedList);
                    }
                    else if(category == null && productType != null)
                    {
                        var modelList = _productRepository.GetAll()
                            .Where(p => p.ProductType.ToString() == productType);
                        var viewModelList = new List<HomeViewModel>();
                        foreach (var item in modelList)
                        {
                            viewModelList.Add(_mapper.Map<HomeViewModel>(item));
                        }

                        var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
                        return View(viewModelPagedList);
                    }
                    else if (category != null && productType == null)
                    {
                        var modelList = _productRepository.GetAll()
                              .Where(p => p.Category.ToString() == category);
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
                        return View("Error");
                    }
                }
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

        public IActionResult ProductDetails(int id)
        {
            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;


            Product product = _productRepository.GetById(id);
            HomeViewModel productHomeViewModel = _mapper.Map<HomeViewModel>(product);
            if (productHomeViewModel == null)
            {
                return View("Error");
            }
            return View(productHomeViewModel);
        }



        [HttpGet]
        public IActionResult ContactUs()
        {
            ViewBag.TotalItemsCount = _shoppingCart.GetCartCountAndTotalAmmountAsync().Result.ItemCount;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(string subject , string message)
        {
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);

            var userEmail = _userManager.GetUserAsync(HttpContext.User).Result.Email;
            var userFullName = _userManager.GetUserAsync(HttpContext.User).Result.FullName;
            var from = new EmailAddress(userEmail, userFullName);

            List<EmailAddress> to = new List<EmailAddress>
            {
              new EmailAddress("donevskipetar@gmail.com", "Petar")
            };

            var htmlContent = $"<p>{message}</p>";
            var displayRecipients = false; // set this to true if you want recipients to see each others mail id 
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", htmlContent, false);
            var response = await client.SendEmailAsync(msg);

            ViewBag.MessageSent = "Message sent.";
            return View("ContactUs");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
