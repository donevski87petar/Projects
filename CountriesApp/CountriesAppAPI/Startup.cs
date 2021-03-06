using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesAppAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CountriesAppAPI.Repository.IRepository;
using CountriesAppAPI.Repository;
using AutoMapper;
using CountriesAppAPI.Mapper;
using System.Reflection;
using System.IO;

namespace AppAPI
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




            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();




            services.AddAutoMapper(typeof(Mappings));



            //Pretty response
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });


            //Register Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("CountriesAppOpenAPISpecCountries", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "CountriesApp API (Countries)",
                    Version = "1",
                    Description = "Travel App API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "donevskipetar@gmail.com",
                        Name = "Petar Donevski"
                    }
                });
                options.SwaggerDoc("CountriesAppOpenAPISpecCities", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "CountriesApp API (Cities)",
                    Version = "1",
                    Description = "Travel App API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Email = "donevskipetar@gmail.com",
                        Name = "Petar Donevski"
                    }
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //add swagger to request pipeline
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/CountriesAppOpenAPISpecCountries/swagger.json", "Countries App API (Countries)");
                options.SwaggerEndpoint("/swagger/CountriesAppOpenAPISpecCities/swagger.json", "Countries App API (Cities)");
                options.RoutePrefix = ""; //set swagger UI to be default page
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
