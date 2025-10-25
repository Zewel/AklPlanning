using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweaterPlanning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweaterPlanning.SessionClass
{
    public class CustomSession:  ControllerBase
    {
        public CustomSession()
        {
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Convert.ToInt32(HttpContext.Session.GetString(SessionCollection.UserId))!= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Login" } });
        }
    }
}
