using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Assistant.Courses;
using TeamworkSystem.Services.AssistantServices;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [Authorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private AssistantCoursesService service;
        public CoursesController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public CoursesController(TeamworkSystemData data)
        {
            this.service = new AssistantCoursesService(data);
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
