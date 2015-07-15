using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DAL;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Demo.Controllers;

namespace Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //builder.RegisterType<DAL.IEmployeeRepository>();
            builder.RegisterType<HomeController>().InstancePerRequest();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));






            


            //// ...or you can register individual controlllers manually.
            //builder.RegisterType<HomeController>().InstancePerRequest();

            //var builder = new ContainerBuilder();

            //Autofac.Integration.Mvc.RegistrationExtensions.RegisterControllers(builder, typeof(MvcApplication).Assembly);



            //builder.Build();
        }
    }
}
