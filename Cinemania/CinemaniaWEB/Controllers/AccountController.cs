using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaniaWEB.Models.IdentityModels;
using CinemaniaWEB.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CinemaniaWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CinemaniaIdentityUser> userManager;
        private readonly SignInManager<CinemaniaIdentityUser> signInManager;
        private readonly RoleManager<CinemaniaIdentityRole> roleManager;


        public AccountController(UserManager<CinemaniaIdentityUser> userManager,
                                 SignInManager<CinemaniaIdentityUser> loginManager,
                                 RoleManager<CinemaniaIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = loginManager;
            this.roleManager = roleManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                CinemaniaIdentityUser user = new CinemaniaIdentityUser();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.FullName = obj.FullName;
                user.BirthDate = obj.BirthDate;

                IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        CinemaniaIdentityRole role = new CinemaniaIdentityRole();
                        role.Name = "Cinemania User";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = roleManager.
                        CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("","Error while creating role!");
                            return View(obj);
                        }
                    }

                    userManager.AddToRoleAsync(user, "Cinemania User").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(obj);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(obj.UserName, obj.Password,obj.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login!");
            }

            return View(obj);
        }



        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
















    }
}
