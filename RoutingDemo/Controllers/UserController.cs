//System namepace imports
using System;
using System.Web.Mvc;

//custom namespace imports
using RoutingDemo.Middlewares;
using RoutingDemo.DBQueries;

namespace RoutingDemo.Controllers
{

    public class UserController : Controller
    {
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(FormCollection formData)
        {
            try
            {
                var responseUser = Users.LoginUserWithEmailAndPassword(formData.Get("email"), formData.Get("password"));
                responseUser.Role = Roles.GetRolesByID(responseUser.ID);
                if (responseUser != null)
                {
                    Session["User"] = responseUser;
                    return RedirectToAction("Index", responseUser.Role.RoleName);
                }

            }
            catch (Exception ex)
            {
                return View("Login");
            }
            return RedirectToAction("Login");

        }

        // GET: User
        [UserAuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
