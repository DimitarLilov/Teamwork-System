﻿namespace TeamworkSystem.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using TeamworkSystem.Data.Contracts;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ITeamworkSystemContext context)
        {
            this.EntityTable = context.Set<T>();
        }

        protected virtual IDbSet<T> EntityTable { get; set; }

        public void Insert(T entity)
        {
            this.EntityTable.Add(entity);
        }

        public void Delete(T entity)
        {
            this.EntityTable.Remove(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.EntityTable.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return this.EntityTable;
        }

        public T GetById(int id)
        {
            return this.EntityTable.Find(id);
        }

        public T FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            return this.EntityTable.FirstOrDefault(predicate);
        }
    }
}