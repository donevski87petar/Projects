using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppWEB.Repository;
using CountriesAppWEB.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CountriesAppWEB
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




            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();





            //Added to make HTTP Calls
            services.AddHttpClient();






            services.AddControllersWithViews().AddRazorRuntimeCompilation();






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();



            ////Add Cors
            //app.UseCors(x => x
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());




            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}