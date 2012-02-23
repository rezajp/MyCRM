using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace MyCRM.Repositories
{
    public class NHibernateUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISession _session;

        public NHibernateUnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _session.BeginTransaction();
        }

        public void End()
        {
            if (_session.IsOpen)
            {
                CommitTransaction();
                _session.Close();
            }
            _session.Dispose();
        }

        private void CommitTransaction()
        {
            if (_session.Transaction != null && _session.Transaction.IsActive)
            {
                try
                {
                    _session.Transaction.Commit();
                }
                catch (Exception)
                {
                    _session.Transaction.Rollback();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            End();
        }
    }
}
