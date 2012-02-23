using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCRM.Model
{
    public class Order:Entity<Guid>
    {
        public virtual string Description { get; set; }
        public virtual double Amount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
