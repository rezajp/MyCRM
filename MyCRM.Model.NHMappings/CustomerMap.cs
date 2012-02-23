using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MyCRM.Model.NHMappings
{
    public sealed class CustomerMap:ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Name);
            Map(c => c.Address);
            HasMany(c => c.Orders).Inverse().LazyLoad();
        }
    }
}
