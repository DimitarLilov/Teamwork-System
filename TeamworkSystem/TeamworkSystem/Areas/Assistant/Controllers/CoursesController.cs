using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Assistant.Courses;
using TeamworkSystem.Services.Contracts.Assistans;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [CustomAuthorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private IAssistantCoursesService service;

        public CoursesController(IAssistantCoursesService service)
        {
            this.service = service;
        }

        // GET: Assistant/Courses
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            AssistantAllCoursesViewModel vm = this.service.GetAllCourses(page, username);
            return View(vm);
        }

        // GET: Assistant/Courses/Details/5
        [Route("{id}")]
        public ActionResult Details(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.AssistingCourse(id, username))
            {
                return this.RedirectToAction("Index", "Courses", new { area = "Assistant" });
            }
            AssistantCourseDetailsViewModel vm = this.service.GetDetails(id);
            return View(vm);
        }

    }
}
