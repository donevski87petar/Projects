using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using X.PagedList;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {

        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderController(
            IShoppingCartRepository shoppingCartRepository,
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }


        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _shoppingCartRepository.GetShoppingCartItemsAsync();
            if (cartItems?.Count() <= 0)
            {
                return RedirectToAction("CartDetails" , "ShoppingCart");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout([FromForm]OrderViewModel orderVM)
        {
            if (!ModelState.IsValid)
            {
                return View(orderVM);
            }
            var order = _mapper.Map<Order>(orderVM);

            var cartItems = await _shoppingCartRepository.GetShoppingCartItemsAsync();


            if (cartItems?.Count() <= 0)
            {
                ModelState.AddModelError("", "Your Cart is empty. Please add products before checkout");
                return View("Error");
            }

            order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _orderRepository.CreateOrderAsync(order);
            await _shoppingCartRepository.ClearCartAsync();

            return View("CheckoutComplete");
        }

        [Authorize]
        public async Task<IActionResult> MyOrder(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 5;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderRepository.GetAllOrdersAsync(userId);

            orders.OrderBy(o => o.OrderPlacedTime);

            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var item in orders)
            {
                orderViewModels.Add(_mapper.Map<OrderViewModel>(item));
            }
            
            var orderViewModelsPagedList = orderViewModels.ToPagedList(pageNumber, pageSize);

            @ViewBag.OrdersCount = orders.Count();

            return View(orderViewModelsPagedList);
        }

        [Authorize(Roles="Administrator")]
        public async Task<IActionResult> GetAllOrders(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 5;

            IEnumerable<Order> orderlist = await _orderRepository.GetAllOrdersAsync();
            orderlist.OrderBy(o => o.OrderPlacedTime);
            var viewModelList = new List<OrderViewModel>();
            foreach (var item in orderlist)
            {
                viewModelList.Add(_mapper.Map<OrderViewModel>(item));
            }

            var viewModelListPaged = viewModelList.ToPagedList(pageNumber, pageSize);

            return View(viewModelListPaged);
        }


    }
}
