using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;

    public class TaskItemMap
        : EntityMap<TaskItem>
    {
        public TaskItemMap()
        {
            Table("TaskItems");

            Map(x => x.Name);
            Map(x => x.Description);

            HasMany(x => x.EstimateEvents)
                .Cascade
                .All();
        }
    }
}
