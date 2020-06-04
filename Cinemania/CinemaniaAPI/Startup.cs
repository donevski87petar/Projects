using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaniaAPI.Data;
using CinemaniaAPI.Mapper;
using CinemaniaAPI.Repository;
using CinemaniaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CinemaniaAPI
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


            //Add Db Context to StartUp
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            //Register services
            services.AddScoped<IMovieRepository, MovieRepository>();



            //Register Auto Mapper
            services.AddAutoMapper(typeof(MovieMappings));



            //Register Swagger generator
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("CinemaniaOpenAPISpec", new Microsoft.OpenApi.Models.OpenApiInfo() { 
                        Title = "Cinemania API",
                        Version = "1"
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

            //Add Swagger 
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/CinemaniaOpenAPISpec/swagger.json", "Cinemania API");
                options.RoutePrefix = ""; // Make Swagger UI default
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
