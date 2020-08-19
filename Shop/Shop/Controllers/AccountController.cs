using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DomainModels.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<AppUser> _passwordHasher;


        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<AppRole> roleManager,
                                 IMapper mapper,
                                 IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.Users.Any(u => u.UserName.ToLower() == registerViewModel.UserName.ToLower()))
                {
                    ModelState.AddModelError("", "The User Name is already taken!");
                }
                else if(registerViewModel.Password != registerViewModel.ConfirmPassword)
                {
                    ModelState.AddModelError("", "The Passwords didnt match!");
                }
                else
                {
                    AppUser user = new AppUser();
                    user.UserName = registerViewModel.UserName;
                    user.Email = registerViewModel.Email;
                    user.FullName = registerViewModel.FullName;
                    user.BirthDate = registerViewModel.BirthDate;

                    IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;

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
                                return View(registerViewModel);
                            }
                        }

                        _userManager.AddToRoleAsync(user, "User").Wait();
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(registerViewModel);
                    }
                }
            }
            return View(registerViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false).Result;


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login!");
                }
            }
            return View(loginViewModel);
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            AppUser appUser = await _userManager.GetUserAsync(User);
            AppUserViewModel appUserViewModel = _mapper.Map<AppUserViewModel>(appUser);
            var roles = _userManager.GetRolesAsync(appUser).Result;
            foreach (var role in roles)
            {
                appUserViewModel.AppRole = role;
            }
            return View(appUserViewModel);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser(AppUserViewModel appUserViewModel)
        {
            AppUser appUser = await _userManager.FindByIdAsync(appUserViewModel.Id);

            if (appUser == null)
            {
                return View("Not Found");
            }

            if (ModelState.IsValid)
            {
                if (appUserViewModel.Password != appUserViewModel.ConfirmPassword)
                {
                    ModelState.AddModelError("", "The Passwords didnt match!");
                }
                else
                {
                    appUser.FullName = appUserViewModel.FullName;
                    appUser.Email = appUserViewModel.Email;
                    appUser.BirthDate = appUserViewModel.BirthDate;
                    appUser.UserName = appUserViewModel.UserName;
                    appUser.PasswordHash = _passwordHasher.HashPassword(appUser, appUserViewModel.Password);

                    IdentityResult result = await _userManager.UpdateAsync(appUser);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Profile", "Account");
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
            return View(appUserViewModel);
        }


        
    }
}