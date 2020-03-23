
using System.Collections.Generic;

namespace RoutingDemo.Models.NonEntityModels
{
    public class DetailUser
    {
        public User User { get; set; }
        public List<RoutesList> Routes { get; set; }
        public Master_Roles Role { get; set; }
    }
}