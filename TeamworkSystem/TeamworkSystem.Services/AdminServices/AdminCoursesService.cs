using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Admin.Courses;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Admin.Courses;
using TeamworkSystem.Services.Contracts.Admin;
using TeamworkSystem.Utillities.Constants;

namespace TeamworkSystem.Services.AdminServices
{


    public class AdminCoursesService:Service, IAdminCoursesService
    {
        public AdminCoursesService(ITeamworkSystemData data) : base(data)
        {
        }

        public AdminAllCoursesViewModel GetAllCourse(int? page)
        {
            AdminAllCoursesViewModel vm = new AdminAllCoursesViewModel();
            IEnumerable<Course> courses = this.data.Courses.GetAll();

            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<AdminCourseViewModel>>(courses);

            var coursesPage = vm.Courses;
            var pager = new Pager(courses.Count(), page);

            vm.Courses = coursesPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public void CreateCourse(AdminCreateCourseBindingModel binding)
        {
            var user = this.data.User.FindByPredicate(u => u.UserName == binding.TrainerUsername);

            Course course = Mapper.Map<AdminCreateCourseBindingModel, Course>(binding);

            Photo photo = this.data.Photos.FindByPredicate(p => p.UrlPthoto == PathConstants.UnknownCourse);
            course.CoursePhoto = photo;

            this.CreateTreinerRole(user.Id);

            Trainer trainer = new Trainer();
            trainer.IdenityUserId = user.Id;
            this.data.Trainers.Insert(trainer);

            course.Trainer = trainer;

            this.data.Courses.Insert(course);
            this.data.SaveChanges();
        }

        private void CreateTreinerRole(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.data.Context.DbContext));
            userManager.AddToRole(userId, "Trainer");
        }

        public AdminEditCourseViewModel GetEditCourse(int id)
        {
            Course course = this.data.Courses.GetById(id);

            return Mapper.Map<Course, AdminEditCourseViewModel>(course);
        }

        public void EditCourse(int id, AdminEditCourseBindingModel binding)
        {
            Course course = this.data.Courses.GetById(id);
            course.Description = binding.Description;
            course.EndDate = binding.EndDate;
            course.StartDate = binding.StartDate;
            course.MaxGrade = binding.MaxGrade;
            this.data.SaveChanges();
        }

        public void AddImage(string pic, int id)
        {
            var path = PathConstants.CoursePath + pic;
            Photo photo = new Photo()
            {
                UrlPthoto = path
            };

            this.data.Photos.Insert(photo);
            this.data.Courses.GetById(id).CoursePhoto = photo;
            this.data.SaveChanges();
        }
    }
}
