using System.IO;
using System.Web;
using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.BindingModels.Admin.Courses;
using TeamworkSystem.Models.ViewModels.Admin.Courses;
using TeamworkSystem.Services.Contracts.Admin;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Courses")]
    public class CoursesController : Controller
    {
        private IAdminCoursesService service;

        public CoursesController(IAdminCoursesService service)
        {
            this.service = service;
        }

        // GET: Admin/Courses
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllCoursesViewModel vm = this.service.GetAllCourse(page);


            return View(vm);
        }

        // GET: Admin/Courses/Create
        [Route("Create")]
        public ActionResult Create()
        {
            AdminCreateCourseViewModel vm = new AdminCreateCourseViewModel();
            return View(vm);
        }

        // POST: Admin/Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create(AdminCreateCourseBindingModel binding)
        {
            if (ModelState.IsValid)
            {
                this.service.CreateCourse(binding);

                return RedirectToAction("Index", "Courses", new {area = "Admin"});
            }
            AdminCreateCourseViewModel vm = new AdminCreateCourseViewModel();
            return View(vm);
        }

        // GET: Admin/Courses/Edit/5
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id)
        {
            AdminEditCourseViewModel vm = this.service.GetEditCourse(id);

            return View(vm);
        }

        // POST: Admin/Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id, AdminEditCourseBindingModel binding)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCourse(id, binding);
//                this.RedirectToAction("Show", "Courses");
            }

            AdminEditCourseViewModel vm = this.service.GetEditCourse(id);
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/UploadCoursePicture")]
        public ActionResult FileUpload(int id,HttpPostedFileBase file)
        {
            var username = this.User.Identity.Name;
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/profile"), pic);

                file.SaveAs(path);


                this.service.AddImage(pic, id);
            }

            return RedirectToAction("Index", "Courses");
        }
    }
}
