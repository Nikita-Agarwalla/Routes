using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoutingDemo.Models.NonEntityModels
{
    public class RouteMappedModel
    {
        public List<Master_Roles> Roles { get; set; }
        public List<RoutesList> Routes { get; set; }
    }
}