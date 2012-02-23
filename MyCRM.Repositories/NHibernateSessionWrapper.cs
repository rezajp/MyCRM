using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Context;

namespace MyCRM.Repositories
{
    public class NHibernateSessionWrapper
    {
        public ISessionFactory SessionFactory { protected get; set; }

        public ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(SessionFactory))
            {
                var session = SessionFactory.OpenSession();
                session.FlushMode = FlushMode.Commit;
                CurrentSessionContext.Bind(session);
            }
            return SessionFactory.GetCurrentSession();
        }

        public void DisposeSession()
        {
            var session = GetCurrentSession();
            session.Close();
            session.Dispose();
        }

        public void BeginTransaction()
        {
            GetCurrentSession().BeginTransaction();
        }

        public void CommitTransaction()
        {
            var session = GetCurrentSession();
            if (session.Transaction.IsActive)
                session.Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            var session = GetCurrentSession();
            if (session.Transaction.IsActive)
                session.Transaction.Rollback();
        }
    }

}
