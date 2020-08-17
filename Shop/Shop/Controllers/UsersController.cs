using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.ViewModels;
using X.PagedList;

namespace Shop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public UsersController(IUserRepository userRepository,
                               IMapper mapper,
                               UserManager<AppUser> userManager,
                               RoleManager<AppRole> roleManager,
                               IPasswordHasher<AppUser> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        public IActionResult AllUsers(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 10;

            var modelList = _userRepository.GetAllUsers();
            var viewModelList = new List<AppUserViewModel>();
            foreach (var item in modelList)
            {
                viewModelList.Add(_mapper.Map<AppUserViewModel>(item));
            }
            ViewBag.UsersCount = viewModelList.Count();
            var viewModelPagedList = viewModelList.ToPagedList(pageNumber, pageSize);
            return View(viewModelPagedList);
        }

        public IActionResult UserDetails(string id)
        {
            AppUser appUser = _userRepository.GetUserById(id);
            if(appUser == null)
            {
                return View("Error");
            }

            AppUserViewModel appUserViewModel = _mapper.Map<AppUserViewModel>(appUser);
            var roles = _userManager.GetRolesAsync(appUser).Result;
            foreach (var role in roles)
            {
                appUserViewModel.AppRole = role;
            }
            return View(appUserViewModel);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.FullName = obj.FullName;
                user.BirthDate = obj.BirthDate;

                IdentityResult result = _userManager.CreateAsync(user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        AppRole role = new AppRole();
                        role.Name = "User";
                        role.RoleDescription = "Perform normal operations.";
                        IdentityResult roleResult = _roleManager.
                        CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creating role!");
                            return View(obj);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "User").Wait();

                    return RedirectToAction("UserDetails", new { id = user.Id});
                }
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult RemoveUser(string id)
        {
            AppUser appUser = _userRepository.GetUserById(id);
            AppUserViewModel appUserViewModel = _mapper.Map<AppUserViewModel>(appUser);
            return View(appUserViewModel);
        }

        [HttpPost]
        public IActionResult RemoveUser(string id , AppUserViewModel appUserVM)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction("AllUsers");
        }

        [HttpGet]
        public IActionResult UpdateUser(string id)
        {
            AppUser appUser = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (appUser == null)
            {
                return View("Error");
            }

            AppUserViewModel appUserViewModel = _mapper.Map<AppUserViewModel>(appUser);
            return View(appUserViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(AppUserViewModel appUserViewModel)
        {
            AppUser appUser = await _userManager.FindByIdAsync(appUserViewModel.Id);

            if (appUser == null)
            {
                return View("Not Found");
            }

            appUser.FullName = appUserViewModel.FullName;
            appUser.Email = appUserViewModel.Email;
            appUser.BirthDate = appUserViewModel.BirthDate;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PasswordHash = _passwordHasher.HashPassword(appUser, appUserViewModel.Password);

            IdentityResult result = await _userManager.UpdateAsync(appUser);

            if (result.Succeeded)
            {
                return RedirectToAction("AllUsers", "Users");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(appUserViewModel);
            }
        }

    }
}
