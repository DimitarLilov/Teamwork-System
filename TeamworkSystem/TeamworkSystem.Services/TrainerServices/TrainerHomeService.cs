﻿using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Trainer.Home;

namespace TeamworkSystem.Services.TrainerServices
{
    public class TrainerHomeService : Service
    {
        public TrainerHomeService(ITeamworkSystemData data) : base(data)
        {
        }

        public TrainerPanelViewModel GetTrainerInfo(string username)
        {
            var trainer = this.data.Trainers.FindByPredicate(t => t.IdentityUser.UserName == username);
            return Mapper.Map<Trainer, TrainerPanelViewModel>(trainer);
        }
    }
}
