using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCRM.Model
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}
