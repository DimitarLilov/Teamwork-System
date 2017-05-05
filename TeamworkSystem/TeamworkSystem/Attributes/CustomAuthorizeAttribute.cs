using System.Linq;
using System.Web.Mvc;

namespace TeamworkSystem.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');
            if (filterContext.HttpContext.Request.IsAuthenticated && !roles.Any(filterContext.HttpContext.User.IsInRole))
            {
               filterContext.Result = new RedirectResult("/");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}