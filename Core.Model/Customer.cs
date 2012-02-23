using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCRM.Model
{
    public class Customer:Entity<int>
    {
        public Customer()
        {
            Orders=new List<Order>();
        }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}
