using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Services.Contracts;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private IProjectsService service;

        public ProjectsController(IProjectsService service)
        {
            this.service = service;
        }

        // GET: Projects
        [HttpGet]
        [Route]
        public ActionResult Index(int? page)
        {
            AllProjectsViewModel vm = this.service.GetAllPublicProjects();

            var projects = vm.Projects;
            var pageSize = 30;
            var pager = new Pager(projects.Count(), page, pageSize);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return View(vm);
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public ActionResult Show(int id)
        {
            if (!this.service.ContainsProject(id))
            {
                return this.HttpNotFound();
            }

            ProjectInfoViewModel vm = this.service.GetProject(id);

            return this.View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.ContainsProject(id))
            {
                return this.HttpNotFound();
            }

            if (!this.service.ContainsUser(id,username))
            {
                return this.RedirectToAction("Show", "Projects",new {id = id});
            }

            EditProjectViewModel vm = this.service.GetEditProject(id);

            return this.View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id,EditProjectBindingModel binding)
        {
            var username = this.User.Identity.Name;

            if (!this.service.ContainsProject(id))
            {
                return this.HttpNotFound();
            }
            if (!this.service.ContainsUser(id, username))
            {
                return this.RedirectToAction("Show", "Projects", new { id = id });
            }
            if (ModelState.IsValid)
            {
                this.service.EditProject(id, binding);

                return this.RedirectToAction("Show", "Projects", new { id = id });
            }
            EditProjectViewModel vm = this.service.GetEditProject(id);

            return this.View(vm);
        }


        [ChildActionOnly]
        [Route("{id:int}/Points")]
        public ActionResult Points(int id)
        {
            if (!this.service.ContainsProject(id))
            {
                return this.HttpNotFound();
            }

            string userName = this.User.Identity.Name;
            IEnumerable<string> assistents = this.service.GetAssistentsNames(id);
            string trainer = this.service.GetTreinerName(id);
            //            if (!this.service.ContainsCriteria(id))
            //            {
            //                return null;
            //            }
            if (!this.service.IsActiveProject(id) || (!assistents.Contains(userName) && !trainer.Contains(userName)) || this.service.IsAssess(userName, id))
            {
                return null;
            }

            IEnumerable<CriteriaViewModel> vm = this.service.GetProjectCriteria(id).ToList();

            return this.PartialView("_Points", vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Points")]
        public ActionResult Points(int id, IList<CriteriaBindingModel> binding)
        {
            if (!this.service.ContainsProject(id))
            {
                return this.HttpNotFound();
            }

            string userName = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.GradeProject(userName, id, binding);
                return this.RedirectToAction("Show", new { id = id });
            }

            IEnumerable<string> assistents = this.service.GetAssistentsNames(id);
            string trainer = this.service.GetTreinerName(id);
            if (!assistents.Contains(userName) && !trainer.Contains(userName))
            {
                return null;
            }

            IEnumerable<CriteriaViewModel> vm = this.service.GetProjectCriteria(id).ToList();

            return this.PartialView("_Points", vm);
        }


        [HttpGet]
        [ChildActionOnly]
        [Route("ProjectButton")]
        public ActionResult ProjectButton(int id)
        {
            var username = this.User.Identity.Name;
            if (this.service.ContainsUser(id,username))
            {
                return this.PartialView("_ProjectButton", id);
            }

            return null;
        }

        [HttpGet]
        [ChildActionOnly]
        [Route("Grade")]
        public ActionResult Grade(int id)
        {
            var username = this.User.Identity.Name;
            if (this.service.ContainsUser(id,username))
            {
                var grade = this.service.GetGrade(id);
                return this.PartialView("_Grade", grade);
            }

            return null;
        }

        [HttpGet]
        [ChildActionOnly]
        [Route("Photos")]
        public ActionResult Photos(int id)
        {
            if (this.service.ContainsProjectGalery(id))
            {
                var gallery = this.service.GetGalery(id);
                return this.PartialView("_Photos", gallery);
            }

            return null;
        }

        [HttpGet]
        [ChildActionOnly]
        [Route("Status")]
        public ActionResult Status(int id)
        {
            if (this.service.ProjectIsPublic(id))
            {
                return this.PartialView("_Public");
            }
            return this.PartialView("_Private");
        }

        [HttpGet]
        [ChildActionOnly]
        [Route("Comment")]
        public ActionResult Comment(int id)
        {
            IEnumerable<CommentViewModel> vm = this.service.GetComments(id);

            return this.PartialView("_Comment", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Comment")]
        public ActionResult Comment(int id, CommentBindingModel binding)
        {
            string userName = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.AddComment(id, binding, userName);

            }

            return this.RedirectToAction("Show", new { id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/UploadPicture")]
        public ActionResult FileUpload(int id,HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/projects"), pic);

                file.SaveAs(path);


                this.service.AddImage(pic, id);
            }

            return RedirectToAction("Show", "Projects", new{id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Gallery")]
        public ActionResult Gallery(int id, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/projects/gallery"), pic);

                file.SaveAs(path);


                this.service.AddImageInGallery(pic, id);
            }

            return RedirectToAction("Show", "Projects", new { id = id });
        }
    }
}