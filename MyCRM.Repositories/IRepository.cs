using System;
using System.Collections.Generic;
using System.Text;
using MyCRM.Model;

namespace MyCRM.Repositories
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        TId Save(T newInstance);
        void Update(T entity);
        void Delete(T entity);
        T Get(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Func<T, bool> predict);
        long Count();

    }
}
