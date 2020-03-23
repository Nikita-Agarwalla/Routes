//System namespace Imports
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

//Custom Namespace Imports
using RoutingDemo.DBContext;
using RoutingDemo.Models;

namespace RoutingDemo.DBQueries
{
    public class Roles
    {
        private readonly static CompanyDBContext _companyDbContext = new CompanyDBContext();
        public static List<SelectListItem> GetRoles()
        {
            List<SelectListItem> rolesItem = new List<SelectListItem>();
            rolesItem.Add(new SelectListItem() { Text = "Select Role", Value = "0" });
            var allRoles = _companyDbContext.Master_Roles.ToList();

            foreach (var role in allRoles)
            {
                rolesItem.Add(new SelectListItem() { Text = role.RoleName, Value = role.ID.ToString() });
            }
            return rolesItem;
        }

        public static Master_Roles GetRolesByID(int ID)
        {
            var RoleID = _companyDbContext.MapUser.Include(model => model.Role).Where(role => role.User.ID == ID).FirstOrDefault();
            return _companyDbContext.Master_Roles.FirstOrDefault(role => role.ID == RoleID.Role.ID);
        }
    }
}