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
                    ModelName = "Pegasus",
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
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "React Infinity",
                    Price = 130
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Shoes,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Pegasus 36",
                    Price = 150
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
                    ModelName = "Swoosh",
                    Price = 120
                },

                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Element",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Hoodies,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Essential",
                    Price = 120
                },

                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.TShirts,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Futura",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.TShirts,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Element",
                    Price = 120
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.TShirts,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Victory",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.TShirts,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "Infinite",
                    Price = 120
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Trousers,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Trousers,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 120
                },
                                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Trousers,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Trousers,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 120
                },
                new Product
                {
                    Category = Category.Male,
                    ProductType = ProductType.Tights,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 100
                },
                new Product
                {
                    Category = Category.Female,
                    ProductType = ProductType.Tights,
                    Brand = Brand.Nike,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ModelName = "xxx",
                    Price = 120
                },
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

