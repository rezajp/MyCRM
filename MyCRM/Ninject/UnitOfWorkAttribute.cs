using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCRM.Repositories;
using Ninject;

namespace MyCRM.Ninject
{
    public class UnitOfWorkAttribute : FilterAttribute, IActionFilter
    {
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        public UnitOfWorkAttribute()
        {
            Order = 0;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UnitOfWork.Begin();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UnitOfWork.End();
        }
    }
}