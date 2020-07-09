using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IActionResult AllUsers()
        {
            var modelList = _userRepository.GetAllUsers();
            var viewModelList = new List<AppUserViewModel>();
            foreach (var item in modelList)
            {
                viewModelList.Add(_mapper.Map<AppUserViewModel>(item));
            }
            return View(viewModelList);
        }





    }
}
