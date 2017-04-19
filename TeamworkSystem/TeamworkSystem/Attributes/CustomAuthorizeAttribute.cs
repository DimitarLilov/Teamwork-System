﻿using System.Linq;
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
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Home/Index.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}