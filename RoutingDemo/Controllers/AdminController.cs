using System;
using System.Diagnostics;
using System.Web.Mvc;
using RoutingDemo.DBQueries;
using RoutingDemo.Models.NonEntityModels;
using RoutingDemo.Middlewares;

namespace RoutingDemo.Controllers
{
    [UserAuthenticationFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        public ViewResult MapUser() => View(Users.FetchAllUser());


        public ViewResult Role(int id)
        {
            ViewData["RoleList"] = Roles.GetRoles();
            return View(Users.FetchUserByID(id));
        }

        [HttpPost]
        public RedirectToRouteResult Role(FormCollection collection)
        {
            Debug.Print(collection.Get("Roles").ToString());
            Debug.Print(collection.Get("UserID").ToString());
            Users.AddRole(Convert.ToInt32(collection.Get("UserID")), Convert.ToInt32(collection.Get("Roles")));
            return RedirectToAction("MapUser");
        }

        public ViewResult Details(int id)
        {
            var UserRole = Roles.GetRolesByID(id);
            return View(new DetailUser() { User = Users.FetchUserByID(id), Role = UserRole, Routes = Routes.GetRoutes(UserRole.RoleName) });
        }

        public RedirectToRouteResult Delete(int id)
        {
            Users.DeleteUser(id);
            return RedirectToAction("MapUser");
        }

    }
}