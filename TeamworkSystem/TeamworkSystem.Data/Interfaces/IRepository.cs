using System;
using System.Linq;
using System.Linq.Expressions;

namespace TeamworkSystem.Data.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T entity);

        void Delete(T entity);

        T FindByPredicate(Expression<Func<T, bool>> predicate);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        T GetById(int id);
    }
}
