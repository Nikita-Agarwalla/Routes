//System Namespace Imports
using System.Collections.Generic;
using System.Linq;

//Custom namespace imports
using RoutingDemo.DBContext;
using RoutingDemo.Models;

namespace RoutingDemo.DBQueries
{
    public class Routes
    {
        private readonly static CompanyDBContext _companyDbContext = new CompanyDBContext();
        public static void AddRoutes(string ControllerName, string ActionName)
        {
            var routeListObject = new Models.RoutesList() { Route = $"{ControllerName}/{ActionName}" };
            var containsRoutes = _companyDbContext.RouteList.Where(route => route.Route.Equals(routeListObject.Route));
            if (containsRoutes.Count() == 0)
            {
                _companyDbContext.RouteList.Add(routeListObject);
                _companyDbContext.SaveChanges();
            }
        }

        public static List<RoutesList> GetRoutes(string rolename) => _companyDbContext.RouteList.Where(route => route.Route.Contains(rolename)).ToList();


    }
}