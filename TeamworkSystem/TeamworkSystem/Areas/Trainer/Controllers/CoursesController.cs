namespace TeamworkSystem.Areas.Trainer.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.BindingModels.Trainer.Courses;
    using TeamworkSystem.Models.ViewModels.Trainer.Courses;
    using TeamworkSystem.Services.Contracts.Trainers;

    [CustomAuthorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private ITrainerCoursesService service;

        public CoursesController(ITrainerCoursesService service)
        {
            this.service = service;
        }

        // GET: Trainer/Courses
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            TrainerAllCourseViewModel vm = this.service.GetTrainerCourses(page, username);
            return this.View(vm);
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
            return this.View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}")]
        public ActionResult Details(int id, IEnumerable<TrainerProjectActiveBindingModel> binding)
        {
            if (this.ModelState.IsValid)
            {
                this.service.ActivateProject(binding);
                return this.RedirectToAction("Details", new { id });
            }

            var username = this.User.Identity.Name;
            if (!this.service.LeadingCourses(username, id))
            {
                return this.RedirectToAction("Index", "Courses");
            }

            TrainerCourseDetailsViewModel vm = this.service.GetCourseDetails(id);
            return this.View(vm);
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
            return this.View(vm);
        }

        // POST: Trainer/Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id, TrainerCourseEditBindingModel binding)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCourse(id, binding);
                return this.RedirectToAction("Edit", "Courses", new { id });
            }

            TrainerCourseEditViewModel vm = this.service.GetEditCourse(id);
            return this.View(vm);
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
            return this.View(vm);
        }

        // POST: Trainer/Courses/5/Assistants
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Assistants")]
        public ActionResult Assistants(int id, TrainerAddAssistantBindingModel binding)
        {
            if (!this.service.ContainsUser(binding.Username))
            {
                return this.RedirectToAction("Assistants", "Courses", new { id });
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddAssistant(id, binding);
                return this.RedirectToAction("Assistants", "Courses", new { id });
            }

            TrainerCourseAssistantsViewModel vm = this.service.GetCourseAssistents(id);
            return this.View(vm);
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
            return this.View(vm);
        }

        // POST: Trainer/Courses/5/Criteria
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Criteria")]
        public ActionResult Criteria(int id, TrainerCriteriaBindingModel binding)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddCriteria(id, binding);
                return this.RedirectToAction("Criteria", "Courses", new { id });
            }

            TrainerCourseCriteriaViewModel vm = this.service.GetCourseCriteria(id);
            return this.View(vm);
        }
    }
}
