using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCRM.Repositories
{
    public interface IUnitOfWork
    {
        void Begin();
        void End();
    }
}
