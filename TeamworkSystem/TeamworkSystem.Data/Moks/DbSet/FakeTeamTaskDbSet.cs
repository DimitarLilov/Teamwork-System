﻿using System.Linq;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.DbSet
{
    public class FakeTeamTaskDbSet : FakeDbSet<TeamTask>
    {
        public override TeamTask Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }

    }
}
