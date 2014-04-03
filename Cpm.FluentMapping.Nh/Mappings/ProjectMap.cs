using Cpm.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    public class ProjectMap
        : EntityMap<Project>
    {
        public ProjectMap()
        {
            Table("Projects");

            Map(x => x.Code).Unique();
            Map(x => x.Name);

            References(x => x.Process).Not.Nullable();
            References(x => x.Organization);
            HasManyToMany(x => x.Peplo);

            HasMany(x => x.WorkItems)
                .Cascade
                .All()
                .LazyLoad();
        }
    }
}
