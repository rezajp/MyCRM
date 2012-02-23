using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MyCRM.Model;

namespace MyCRM.Repositories
{
    public interface IPagedSortableRepository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    {

        IEnumerable<T> FindAll(int page, int pageSize, IDictionary<Expression<Func<T, object>>, SortDirection> sortParameters);
        IEnumerable<T> Find(int page, int pageSize, IDictionary<Expression<Func<T, object>>, SortDirection> sortParameters, Func<T, bool> predict);

    }
}