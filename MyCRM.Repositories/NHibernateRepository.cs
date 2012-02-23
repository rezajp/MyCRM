using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyCRM.Model;

namespace MyCRM.Repositories
{
    public class NHibernateRepository<T, TId> : IPagedSortableRepository<T, TId> where T : Entity<TId>
    {
        public NHibernateSessionWrapper SessionWrapper { get; set; }
        public TId Save(T newInstance)
        {
            return (TId)SessionWrapper.GetCurrentSession().Save(newInstance);
        }

        public void Update(T entity)
        {
            SessionWrapper.GetCurrentSession().Update(entity);
        }

        public void Delete(T entity)
        {
            SessionWrapper.GetCurrentSession().Delete(entity);
        }

        public T Get(TId id)
        {
            return SessionWrapper.GetCurrentSession().Get<T>(id);
        }

        public IEnumerable<T> FindAll()
        {
            return SessionWrapper.GetCurrentSession().QueryOver<T>().Future();
        }

        public IEnumerable<T> Find(Func<T, bool> predict)
        {
            return SessionWrapper.GetCurrentSession().QueryOver<T>().Future().Where(predict);
        }
        public long Count(Func<T, bool> predict)
        {
            return SessionWrapper.GetCurrentSession().QueryOver<T>().Future().LongCount(predict);
        }

        public IEnumerable<T> FindAll(int page, int pageSize, IDictionary<Expression<Func<T, object>>, SortDirection> sortParameters)
        {
            var query = SessionWrapper.GetCurrentSession().QueryOver<T>();
            query = sortParameters.Aggregate(query, (current, sort) => sort.Value == SortDirection.Ascending ? current.OrderBy(sort.Key).Asc : current.OrderBy(sort.Key).Desc);
            int skip = Math.Min(0, (page - 1) * pageSize);
            return query.Skip(skip).Take(pageSize).Future();
        }
        public IEnumerable<T> Find(int page, int pageSize, IDictionary<Expression<Func<T, object>>, SortDirection> sortParameters, Func<T, bool> predict)
        {
            return FindAll(page, pageSize, sortParameters).Where(predict);
        }

        public long Count()
        {
            return SessionWrapper.GetCurrentSession().QueryOver<T>().Future().LongCount();
        }
    }
}