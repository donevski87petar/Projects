using Autofac;
using Autofac.Integration.Mvc;
using ShoppingApp.Data.Models;
using ShoppingApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApp.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);



            builder.RegisterType<ProductData>().As<IProduct>().InstancePerRequest();
            builder.RegisterType<ProductDbContext>().InstancePerRequest();



            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}