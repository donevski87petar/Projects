using Microsoft.AspNetCore.Identity;
using Shop.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.DomainModels.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Shop.DataAccess.Data.Initializer
{
    public static class IdentityDataInitializer
    {
        public static void SeedData(UserManager<AppUser> userManager,
                                    RoleManager<AppRole> roleManager,
                                    ApplicationDbContext dbContext)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedProducts(dbContext);
        }

        public static void SeedProducts(ApplicationDbContext dbContext)
        {
            var products = new List<Product>
            {
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Nike Air Max 97",
                    Price = 180
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Cortez",
                    Price = 70
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Air VaporMax Plus",
                    Price = 170
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Air Max ExoSense",
                    Price = 150
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Air Max Tail Wind",
                    Price = 120
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Air Zoom Pegasus",
                    Price = 130
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "React Infinity",
                    Price = 150
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Pegasus Trail 2",
                    Price = 130
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "React Phantom Run",
                    Price = 140
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Juniper Trail",
                    Price = 120
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Tech Fleece",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "New York City Pullover",
                    Price = 120
                },
                new Product
                                {
                    Category = Category.Male,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "SB",
                    Price = 80
                },
                new Product
                                {
                    Category = Category.Male,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "React Phantom Run",
                    Price = 140
                }
            };

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(products);
                dbContext.SaveChanges();
            }
        }

        public static void SeedUsers(UserManager<AppUser> userManager)
        {

            if (userManager.FindByNameAsync("user").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "user";
                user.Email = "user@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 1, 1);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"User").Wait();
                }
            }


            if (userManager.FindByNameAsync("admin").Result == null)
            {
                AppUser user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@mail.com";
                user.FullName = "Petar Donevski";
                user.BirthDate = new DateTime(1987, 1, 1);

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Administrator").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                AppRole role = new AppRole();
                role.Name = "NormalUser";
                role.RoleDescription = "Perform normal operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                AppRole role = new AppRole();
                role.Name = "Administrator";
                role.RoleDescription = "Perform all the operations.";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }


}

