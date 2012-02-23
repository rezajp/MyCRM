using System;
using MyCRM.Repositories;
using Ninject;
using Ninject.Modules;
using MyCRM.Model;

namespace MyCRM.Ninject
{
    public class RepositoriesModule:NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IPagedSortableRepository<Customer, int>>()
                .To<NHibernateRepository<Customer, int>>()
                .InSingletonScope()
                .WithPropertyValue("SessionWrapper", c => c.Kernel.Get<NHibernateSessionWrapper>());
            
            Kernel.Bind<IPagedSortableRepository<Order, Guid>>()
                .To<NHibernateRepository<Order, Guid>>()
                .InSingletonScope()
                .WithPropertyValue("SessionWrapper", c => c.Kernel.Get<NHibernateSessionWrapper>());
            
        }
    }
}
