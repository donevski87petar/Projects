using Autofac;
using Autofac.Integration.Mvc;
using OdeToFood.Data;
using OdeToFood.Services.Repository;
using OdeToFood.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            builder.RegisterType<CuisineRepository>().As<ICuisineRepository>().InstancePerRequest();
            builder.RegisterType<RestaurantRepository>().As<IRestaurantRepository>().InstancePerRequest();
            builder.RegisterType<MenuItemRepository>().As<IMenuItemRepository>().InstancePerRequest();

            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();



            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}