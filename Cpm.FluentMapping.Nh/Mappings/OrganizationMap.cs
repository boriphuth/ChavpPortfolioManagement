using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;
    using FluentNHibernate.Mapping;

    public class OrganizationMap
        : EntityMap<Organization>
    {
        public OrganizationMap()
        {
            Table("Organizations");

            Map(x => x.Name, "Name").Unique();

            HasMany(x => x.Departments)
                .Cascade
                .All();

            HasMany(x => x.Portfolio)
                .Cascade
                .All()
                .LazyLoad();
        }
    }
}
