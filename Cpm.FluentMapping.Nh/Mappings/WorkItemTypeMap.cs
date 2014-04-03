using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;

    public class WorkItemTypeMap
        : EntityMap<WorkItemType>
    {
        public WorkItemTypeMap()
        {
            Table("WorkItemTypes");

            Map(x => x.Name).Unique();
            Map(x => x.Description);
        }
    }
}
