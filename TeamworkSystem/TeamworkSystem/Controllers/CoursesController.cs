using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private CoursesService service;
        public CoursesController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public CoursesController(TeamworkSystemData data)
        {
            this.service = new CoursesService(data);
        }
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
    }
}