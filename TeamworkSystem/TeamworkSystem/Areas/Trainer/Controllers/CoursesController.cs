using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.BindingModels.Trainer;
using TeamworkSystem.Models.BindingModels.Trainer.Courses;
using TeamworkSystem.Models.ViewModels.Trainer.Courses;
using TeamworkSystem.Services.TrainerServices;

namespace TeamworkSystem.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private TrainerCoursesService service;
        public CoursesController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public CoursesController(TeamworkSystemData data)
        {
            this.service = new TrainerCoursesService(data);
        }

        // GET: Trainer/Courses
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            TrainerAllCourseViewModel vm = this.service.GetTrainerCourses(page, username);
            return View(vm);
        }

        // GET: Trainer/Courses/Details/5
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }
            TrainerCourseDetailsViewModel vm = this.service.GetCourseDetails(id);
            return View(vm);
        }

        [HttpPost]
        [Route("{id:int}")]
        public ActionResult Details(int id, IEnumerable<TrainerProjectActiveBindingModel> binding)
        {
            if (ModelState.IsValid)
            {
                this.service.ActivateProject(binding);
                return this.RedirectToAction("Details", new { id = id });
            }

            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }

            TrainerCourseDetailsViewModel vm = this.service.GetCourseDetails(id);
            return View(vm);
        }

        // GET: Trainer/Courses/Edit/5
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }

            TrainerCourseEditViewModel vm = this.service.GetEditCourse(id);
            return View(vm);
        }

        // POST: Trainer/Courses/Edit/5
        [HttpPost]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id, TrainerCourseEditBindingModel binding)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCourse(id, binding);
                return this.RedirectToAction("Edit", "Courses", new { id = id });
            }
            TrainerCourseEditViewModel vm = this.service.GetEditCourse(id);
            return View(vm);
        }

        // GET: Trainer/Courses/5/Assistants
        [Route("{id:int}/Assistants")]
        public ActionResult Assistants(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }

            TrainerCourseAssistantsViewModel vm = this.service.GetCourseAssistents(id);
            return View(vm);
        }

        // POST: Trainer/Courses/5/Assistants
        [HttpPost]
        [Route("{id:int}/Assistants")]
        public ActionResult Assistants(int id, TrainerAddAssistantBindingModel binding)
        {
            if (!this.service.ContainsUser(binding.Username))
            {

                return this.RedirectToAction("Assistants", "Courses", new { id = id });
            }
            if (ModelState.IsValid)
            {
                this.service.AddAssistant(id, binding);
                return this.RedirectToAction("Assistants", "Courses", new { id = id });
            }

            TrainerCourseAssistantsViewModel vm = this.service.GetCourseAssistents(id);
            return View(vm);
        }

        // GET: Trainer/Courses/5/Criteria
        [Route("{id:int}/Criteria")]
        public ActionResult Criteria(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }

            TrainerCourseCriteriaViewModel vm = this.service.GetCourseCriteria(id);
            return View(vm);
        }

        // POST: Trainer/Courses/5/Criteria
        [HttpPost]
        [Route("{id:int}/Criteria")]
        public ActionResult Criteria(int id, TrainerCriteriaBindingModel binding)
        {
            if (ModelState.IsValid)
            {
                this.service.AddCriteria(id, binding);
                return this.RedirectToAction("Criteria", "Courses", new { id = id });
            }

            TrainerCourseAssistantsViewModel vm = this.service.GetCourseAssistents(id);
            return View(vm);
        }
    }
}
