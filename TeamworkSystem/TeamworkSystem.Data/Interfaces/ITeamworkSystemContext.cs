using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Interfaces
{
    public interface ITeamworkSystemContext
    {
        IDbSet<Project> Projects { get; }

        IdentityDbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
