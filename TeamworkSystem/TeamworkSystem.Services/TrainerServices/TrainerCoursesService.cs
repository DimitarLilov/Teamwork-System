using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Trainer;
using TeamworkSystem.Models.BindingModels.Trainer.Courses;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Trainer.Courses;
using TeamworkSystem.Models.ViewModels.Trainer.Projects;

namespace TeamworkSystem.Services.TrainerServices
{
    public class TrainerCoursesService:Service
    {
        public TrainerCoursesService(ITeamworkSystemData data) : base(data)
        {
        }

        public TrainerAllCourseViewModel GetTrainerCourses(int? page, string username)
        {
            var courses = this.data.Trainers.FindByPredicate(t => t.IdentityUser.UserName == username).LeadingCourses;

            TrainerAllCourseViewModel vm = new TrainerAllCourseViewModel();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<TrainerCourseViewModel>>(courses);

            var coursesPage = vm.Courses;
            var pager = new Pager(courses.Count(), page);

            vm.Courses = coursesPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public bool LeadingCourses(string username, int id)
        {
            var trainer = this.data.Trainers.FindByPredicate(t => t.IdentityUser.UserName == username);
            if (trainer.LeadingCourses.FirstOrDefault(c => c.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public TrainerCourseDetailsViewModel GetCourseDetails(int id)
        {
            var course = this.data.Courses.GetById(id);
            TrainerCourseDetailsViewModel vm = new TrainerCourseDetailsViewModel
            {
                Course = Mapper.Map<Course, TrainerCourseViewModel>(course),
                Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<TrainerProjectViewModel>>(course.Projects)
            };
            return vm;
        }

        public void ActivateProject(IEnumerable<TrainerProjectActiveBindingModel> binding)
        {
            foreach (var model in binding)
            {
                this.data.Projects.FindByPredicate(p => p.Id == model.ProjectId).IsActive = model.IsActive;
            }
            this.data.SaveChanges();
        }

        public TrainerCourseEditViewModel GetEditCourse(int id)
        {
            var course = this.data.Courses.GetById(id);
            return Mapper.Map<Course, TrainerCourseEditViewModel>(course);
        }

        public void EditCourse(int id, TrainerCourseEditBindingModel binding)
        {
            var course = this.data.Courses.GetById(id);
            course.Description = binding.Description;
            course.MaxGrade = binding.MaxGrade;
            this.data.SaveChanges();
        }

        public TrainerCourseAssistantsViewModel GetCourseAssistents(int id)
        {
            var course = this.data.Courses.GetById(id);
            TrainerCourseAssistantsViewModel vm = new TrainerCourseAssistantsViewModel
            {
                Course = Mapper.Map<Course, TrainerCourseViewModel>(course),
                Assistants = Mapper.Map<IEnumerable<Assistent>,IEnumerable<TrainerCourseAssistantViewModel>>(course.Assistents)
            };
            return vm;
        }

        public void AddAssistant(int id, TrainerAddAssistantBindingModel binding)
        {
            var course = this.data.Courses.GetById(id);

            var user = this.data.User.FindByPredicate(u => u.UserName == binding.Username);


            this.CreateTreinerRole(user.Id);

            Assistent assistant = new Assistent();
            assistant.IdenityUserId = user.Id;
            this.data.Assistents.Insert(assistant);

            course.Assistents.Add(assistant);

            this.data.SaveChanges();
        }

        private void CreateTreinerRole(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.data.Context.DbContext));
            userManager.AddToRole(userId, "Assistant");
        }

        public bool ContainsUser(string username)
        {
            var user = this.data.User.FindByPredicate(u => u.UserName == username);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public TrainerCourseCriteriaViewModel GetCourseCriteria(int id)
        {
            var course = this.data.Courses.GetById(id);
            TrainerCourseCriteriaViewModel vm = new TrainerCourseCriteriaViewModel
            {
                Course = Mapper.Map<Course, TrainerCourseViewModel>(course),
                Criteria = Mapper.Map<IEnumerable<Criteria>, IEnumerable<TrainerCriteriaViewModel>>(course.Criteria)
            };

            return vm;
        }

        public void AddCriteria(int id, TrainerCriteriaBindingModel binding)
        {
            Criteria criteria = new Criteria()
            {
                Name = binding.Name
            };
            this.data.Criteria.Insert(criteria);

            var course = this.data.Courses.GetById(id);
            course.Criteria.Add(criteria);

            this.data.SaveChanges();
        }
    }
}
