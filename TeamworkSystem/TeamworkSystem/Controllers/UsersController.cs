﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Users;
using TeamworkSystem.Models.ViewModels.Users;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UsersService service;
        public UsersController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public UsersController(TeamworkSystemData data) 
        {
            this.service = new UsersService(data);
        }

        [HttpGet]
        [Route("{username}")]
        public ActionResult Show(string username)
        {
            if (!this.service.ContainsUser(username))
            {
                return this.HttpNotFound();
            }

            if (username.IsNullOrWhiteSpace() || username == this.User.Identity.Name)
            {
                return RedirectToAction("MyProfile", "Users");
            }
            ProfileViewModel vm = this.service.GetUserProfile(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("Profile")]
        [Authorize]
        public ActionResult MyProfile()
        {
            string username = this.User.Identity.Name;

            ProfileViewModel vm = this.service.GetUserProfile(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize]
        public ActionResult Edit()
        {
            string username = this.User.Identity.Name;

            EditUserViewModel vm = this.service.GetEditUser(username);
            return this.View(vm);
        }

        [HttpPost]
        [Route("Edit")]
        [Authorize]
        public ActionResult Edit(EditUserBindingModel binding)
        {
            string username = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.EditUser(username,binding);
                return this.RedirectToAction("MyProfile");
            }

            EditUserViewModel vm = this.service.GetEditUser(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Teams")]
        public ActionResult Teams(string username, int? page)
        {
            if (!this.service.ContainsUser(username))
            {
                return this.HttpNotFound();
            }

            AllUsersTeamsViewModel vm = this.service.GetAllUsersTeams(username, page);

           
            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Projects")]
        public ActionResult Projects(string username, int? page)
        {
            if (!this.service.ContainsUser(username))
            {
                return this.HttpNotFound();
            }

            AllUsersProjectsViewModel vm = this.service.GetAllUsersProjects(username);

            var projects = vm.Projects;
            var pager = new Pager(projects.Count(), page);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Collaborators")]
        public ActionResult Collaborators(string username, int? page)
        {
            if (!this.service.ContainsUser(username))
            {
                return this.HttpNotFound();
            }

            AllUsersCollaboratorsViewModel vm = this.service.GetAllUsersCollaborators(username);

            var collaborators = vm.Collaborators;
            var pager = new Pager(collaborators.Count(), page);

            vm.Collaborators = collaborators.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [ChildActionOnly]
        [Route("Gender")]
        public ActionResult Gender(string gender)
        {
            if (gender == "Female")
            {
                return this.PartialView("_FemaleGender", gender);
            }

            return this.PartialView("_MaleGender", gender);
        }

        [ChildActionOnly]
        [Route("GetUserInfo")]
        public ActionResult GetUserInfo(string username)
        {
            UserInfoViewModel vm = this.service.GetUserInfo(username);

            return this.PartialView("_UserInfo", vm);
        }

        [HttpPost]
        [Route("UploadProfilePicture")]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var username = this.User.Identity.Name;
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/profile"), pic);

                file.SaveAs(path);


                this.service.AddImage(pic, username);
            }

            return RedirectToAction("MyProfile", "Users");
        }

        [HttpPost]
        [Route("AutoCompleteUser")]
        public JsonResult AutoCompleteUser(string prefix)
        {
            IEnumerable<string> usernames = this.service.GettUsernames();

            var username = usernames.Where(u => u.StartsWith(prefix.ToLower()));

            return Json(username, JsonRequestBehavior.AllowGet);
        }
    }
}