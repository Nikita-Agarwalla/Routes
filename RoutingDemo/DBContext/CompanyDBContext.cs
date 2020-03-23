//System Namespace Import
using System.Data.Entity;

//Custom Namespace Import
using RoutingDemo.Models;

namespace RoutingDemo.DBContext
{
    public class CompanyDBContext : DbContext
    {
        #region "Constructor"
        public CompanyDBContext() : base(){}
        #endregion

        #region "Properties"
        public DbSet<Master_Roles> Master_Roles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RoutesList> RouteList { get; set; }
        public DbSet<MapUser> MapUser { get; set; }

        #endregion
    }
}