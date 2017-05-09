namespace TeamworkSystem.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using TeamworkSystem.Models;
    using TeamworkSystem.Models.ViewModels.Courses;
    using TeamworkSystem.Services.Contracts;

    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private ICoursesService service;

        public CoursesController(ICoursesService service)
        {
            this.service = service;
        }

        // GET: Course
        [Route]
        public ActionResult Index(int? page)
        {
            AllCoursesViewModel vm = this.service.GetAllCourse();

            var courses = vm.Courses;
            var pageSize = 30;
            var pager = new Pager(courses.Count(), page, pageSize);

            vm.Courses = courses.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Show(int id, int? page)
        {
            if (!this.service.ContainsCourse(id))
            {
                return this.HttpNotFound();
            }

            CourseInfoViewModel vm = this.service.GetCourse(id);

            var projects = vm.Projects;
            var pager = new Pager(projects.Count(), page);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }
    }
}