using System.Web.Mvc;
using System;
using System.Web;

namespace TwitsNearby.Security
{
    /// <summary>
    /// 
    /// An action secured with this attribute will ensure that the UserManager holds login credentials     
    /// of some sort (username not null or empty), or will force a redirect to the login page.     
    /// This attribute is intended to replace the built in <authorization/> section of web.config     
    /// Using this on an Ajax call may lead to misleading results, where the Ajax call receives a      
    /// 200 OK result, and an HTML page rather than the JSON it was probably expecting.     
    /// </summary>             
    public class AuthorizeAgainstUserManager : AuthorizeAttribute
    {         
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!UserManager.HasCredentials)                
               filterContext.Result = (new JsonResult() { Data = "401 not authorized" });         
        }     
    } 
}
