﻿namespace TeamworkSystem.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.ViewModels.Admin.Users;
    using TeamworkSystem.Services.Contracts.Admin;

    [CustomAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private IAdminUsersService service;

        public UsersController(IAdminUsersService service)
        {
            this.service = service;
        }

        // GET: Admin/Users
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllUsersViewModel vm = this.service.GetAllUsers(page);

            return this.View(vm);
        }
    }
}
