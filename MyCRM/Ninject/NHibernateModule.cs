using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyCRM.Repositories;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Ninject.Modules;
using MyCRM.Model.NHMappings;

namespace MyCRM.Ninject
{
    public class NHibernateModule:NinjectModule
    {

        public override void Load()
        {
            Kernel.Bind<ISessionFactory>()
                .ToMethod(c => GetSessionFactory())
                .InSingletonScope();
          
            Kernel.Bind<NHibernateSessionWrapper>()
                .ToSelf()
                .InSingletonScope()
                .WithPropertyValue("SessionFactory",c =>c.Kernel.Get<ISessionFactory>());

            Kernel.Bind<IUnitOfWork>()
                .To<NHibernateUnitOfWork>()
                .WithConstructorArgument("session", c => c.Kernel.Get<NHibernateSessionWrapper>().GetCurrentSession());
        }
        private ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.Database("MyCRMDB").Server(".").TrustedConnection()))
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .CurrentSessionContext("web")
                //Uncomment the line below to create your database for the first time
                //.ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildSessionFactory();


        }
    }
}
