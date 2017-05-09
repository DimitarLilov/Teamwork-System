namespace TeamworkSystem.Services.Contracts.Admin
{
    using TeamworkSystem.Models.BindingModels.Admin.Courses;
    using TeamworkSystem.Models.ViewModels.Admin.Courses;

    public interface IAdminCoursesService
    {
        AdminAllCoursesViewModel GetAllCourse(int? page);

        void CreateCourse(AdminCreateCourseBindingModel binding);

        AdminEditCourseViewModel GetEditCourse(int id);

        void EditCourse(int id, AdminEditCourseBindingModel binding);

        void AddImage(string pic, int id);
    }
}
