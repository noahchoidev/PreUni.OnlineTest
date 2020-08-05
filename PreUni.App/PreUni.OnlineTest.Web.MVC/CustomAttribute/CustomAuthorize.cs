using PreUni.Core.Model.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Security.Claims;

namespace PreUni.OnlineTest.Web.MVC.CustomAttribute
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
            {
                throw new ArgumentException("roles");
            }

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }

            // where does this role come from?
            var myRoles = ((ClaimsIdentity)filterContext.HttpContext.User.Identity).Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value);

            foreach (var role in myRoles)
            {
                if (this.Roles.Contains(role.ToString()) == true)
                    return;
                else
                    filterContext.Result = new RedirectToRouteResult
                                           (
                                                new System.Web.Routing.RouteValueDictionary
                                                (
                                                    new
                                                    {
                                                        controller = "Home",
                                                        action = "HandleTheUnauthorized",
                                                        Area = "",
                                                        message = "Your Role is not permitted in administrator"
                                                    }
                                                )
                                            );
            }
        }
    }
}