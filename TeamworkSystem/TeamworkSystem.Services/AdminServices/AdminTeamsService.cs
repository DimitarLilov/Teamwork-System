﻿namespace TeamworkSystem.Services.AdminServices
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Models;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;
    using TeamworkSystem.Models.ViewModels.Admin.Teams;
    using TeamworkSystem.Services.Contracts.Admin;

    public class AdminTeamsService : Service, IAdminTeamsService
    {
        public AdminTeamsService(ITeamworkSystemData data) : base(data)
        {
        }

        public AdminAllTeamsViewModel GetAllTeams(int? page)
        {
            var teams = this.data.Teams.GetAll();

            AdminAllTeamsViewModel vm =
                new AdminAllTeamsViewModel
                {
                    Teams = Mapper.Map<IEnumerable<Team>, IEnumerable<AdminTeamViewModel>>(
                            teams)
                };

            var teamsPage = vm.Teams;
            var pager = new Pager(teamsPage.Count(), page);

            vm.Teams = teamsPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public AdminTeamDetailsViewModel GetTeamDetails(int id)
        {
            Team team = this.data.Teams.GetById(id);
            IEnumerable<Student> members = team.Members;

            AdminTeamDetailsViewModel vm =
                new AdminTeamDetailsViewModel
                {
                    Team = Mapper.Map<Team, AdminTeamViewModel>(team),
                    Description = team.Description,
                    Members = Mapper.Map<IEnumerable<Student>, IEnumerable<AdminTeamMembersViewModel>>(members)
                };

            return vm;
        }
    }
}
