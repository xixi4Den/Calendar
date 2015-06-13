using System;
using System.Linq;
using System.Linq.Expressions;
using Calendar.Entities;

namespace Calendar.DataAccess
{
    public interface IRepository<T> where T : BaseDbEntity
    {
        T GetById(Guid id);

        IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params string[] includeProperties);

        void InsertOrUpdate(T entity);

        void Delete(T entity);

        void Delete(Guid id);

        int Count(Expression<Func<T, bool>> filter);
    }
}