namespace TeamworkSystem.Services.Contracts
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.BindingModels.Teams;
    using TeamworkSystem.Models.ViewModels.Projects;
    using TeamworkSystem.Models.ViewModels.Teams;
    using TeamworkSystem.Models.ViewModels.Teams.Board;

    public interface ITeamsService
    {
        TeamViewModel GetTeam(int id);

        IEnumerable<string> GetMembersName(int id);

        AllTeamsProjectsViewModel GetAllProjects(int id);

        TeamInfoViewModel GetTeamInfo(int id);

        AllTeamsCoursesViewModel GetAllTaemsCourses(int id);

        BoardViewModel GetTeamBoard(int id, string username);

        TeamTasksViewModel GetTeamTasks(int id);

        IEnumerable<string> GettUsernames();

        int CreateTeam(CreateTeamBindingModel binding, string username);

        void AddMember(int id, AddMemberBindingModel binding);

        bool ContainsUser(AddMemberBindingModel binding);

        AddTaskViewModel GetTeamInfoForTask(int id);

        void AddTask(int id, AddTaskBindingModel binding, string username);

        void CompleteTasks(CompleteTasksBindingModel binding);

        BoardProjectsViewModel GetTeamBoardProjects(int id);

        IEnumerable<ProjectCoursesViewModel> GetAllCourses();

        void CreateProject(int id, AddProjectBindingModel binding);

        bool ContainsTeam(int id);

        BoardInfoViewModel GetBoardInfo(int id);

        MembersViewModel GetAllMembers(int id);

        EditTeamViewModel GetEditTeam(int id);

        void EditTeam(EditTeamBindingModel binding, int id);
    }
}
