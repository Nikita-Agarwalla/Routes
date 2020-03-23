using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RoutingDemo.DBQueries;

namespace RoutingDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.GetAllControllerAndActionName();
        }

        public void GetAllControllerAndActionName()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(RoutingDemo.MvcApplication));

            var controlleractionlist = assembly.GetTypes()
            .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            .Select(x => new
            {
                Controller = x.DeclaringType.Name,
                Action = x.Name
            })
            .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            foreach(var controllerAction in controlleractionlist)
            {
                Routes.AddRoutes(controllerAction.Controller.Replace("Controller", ""), controllerAction.Action);
            }

        }
    }
}
