using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace MyCRM.Model.NHMappings
{
    public sealed class OrderMap:ClassMap<Order>
    {
        public OrderMap()
        {
            Id(o => o.Id).GeneratedBy.Guid();
            Map(o => o.Description);
            Map(o => o.Amount);
            References(o => o.Customer);
        }
    }
}
