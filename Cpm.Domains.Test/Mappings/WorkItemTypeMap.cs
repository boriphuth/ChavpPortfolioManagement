using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Test.Mappings
{
    using Cpm.Domains.Entities;

    internal class WorkItemTypeMap
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
