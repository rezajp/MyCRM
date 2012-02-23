using MyCRM.Controllers;
using MyCRM.Repositories;
using Ninject;
using Ninject.Modules;
using MyCRM.Model;

namespace MyCRM.Ninject
{
    public class ControllerModule:NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<CustomerController>()
                .ToSelf()
                .WithPropertyValue("CustomerRepository",
                                                                     c =>
                                                                     c.Kernel.Get
                                                                         <IPagedSortableRepository<Customer, int>>());

        }
    }
}
