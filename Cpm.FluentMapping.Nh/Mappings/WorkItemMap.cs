using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;

    public class WorkItemMap
        : EntityMap<WorkItem>
    {
        public WorkItemMap()
        {
            Table("WorkItems");

            Map(x => x.Name);
            Map(x => x.Description);

            References(x => x.Phase).Not.Nullable();
            References(x => x.WorkItemType).Not.Nullable();

            HasMany(x => x.TaskItems)
                .Cascade
                .All();

            HasMany(x => x.EstimateEvents)
                .Cascade
                .All();
        }
    }
}
