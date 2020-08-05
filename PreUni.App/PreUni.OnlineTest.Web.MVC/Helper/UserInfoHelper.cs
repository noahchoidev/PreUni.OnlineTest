using PreUni.Core.Model.Local;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace PreUni.OnlineTest.Web.MVC.Helper
{
    static public class UserInfoHelper
    {
        public static string GetFullName(this System.Security.Principal.IPrincipal usr)
        {
            var fullNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("UesrFullName");
            if (fullNameClaim != null)
                return fullNameClaim.Value;

            return "";
        }

        public static IEnumerable<string> GetUserRole(this Controller controller)
        {
            var myRoles = ((ClaimsIdentity)controller.HttpContext.User.Identity)
                            .Claims
                            .Where(c => c.Type == ClaimTypes.Role)
                            .Select(c => c.Value);

            return myRoles;
        }

        public static bool ExistsTargetRoleFromMyRoles(IEnumerable<string> myRoles,params RoleEnum[] targetTypes)
        {
            foreach (var role in myRoles)
                foreach (var targetType in targetTypes)
                    if (role == targetType.ToString())
                        return true;
            
            return false;
        }
    }
}