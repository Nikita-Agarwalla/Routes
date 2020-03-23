using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

using RoutingDemo.DBQueries;
using RoutingDemo.Models;

namespace RoutingDemo.Middlewares
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Check Session is Empty Then set as Result is HttpUnauthorizedResult 
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["User"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }
            var user = (User)(filterContext.HttpContext.Session["User"]);
            var authorizedUrls = Routes.GetRoutes(user.Role.RoleName);
            var currentURL = $"{filterContext.RouteData.Values["Controller"]}/{filterContext.RouteData.Values["Action"]}";

            foreach(var url in authorizedUrls)
            {
                if (url.Route.Equals(currentURL))
                    return;
            }
            filterContext.Result = new HttpUnauthorizedResult();

        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "AccessDenied"
                };
            }
        }
    }
}