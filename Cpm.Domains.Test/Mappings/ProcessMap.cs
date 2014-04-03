using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Test.Mappings
{
    using Cpm.Domains.Entities;

    internal class ProcessMap
        : EntityMap<Process>
    {
        public ProcessMap()
        {
            Table("Processes");

            Map(x => x.Name).Unique();
            Map(x => x.ShortName);

            HasMany(x => x.Phases)
                .Cascade
                .All();

            HasMany(x => x.WorkItemTypes)
                .Cascade
                .All();
        }
    }
}
