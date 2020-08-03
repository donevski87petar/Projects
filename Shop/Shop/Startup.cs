using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.DataAccess.Data;
using Shop.DataAccess.Data.Initializer;
using Shop.DataAccess.Data.Repository;
using Shop.DataAccess.Data.Repository.IRepository;
using Shop.DomainModels.Models;
using Shop.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IShoppingCartRepository>(sp => ShoppingCartRepository.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();///////////////////////////////////




            services.AddAutoMapper(typeof(Mappings));



            services.AddMemoryCache();//////////////////////////////////////////////////////////////////////////////



            services.AddControllersWithViews();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/UnAuthorized";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IWebHostEnvironment env, 
                              UserManager<AppUser> userManager,
                              RoleManager<AppRole> roleManager,
                              ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();



            app.UseAuthentication(); 
            app.UseAuthorization(); 


            IdentityDataInitializer.SeedData(userManager, roleManager, dbContext);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
