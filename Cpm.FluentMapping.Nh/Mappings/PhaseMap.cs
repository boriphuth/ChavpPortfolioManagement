using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;

    public class PhaseMap
        : EntityMap<Phase>
    {
        public PhaseMap()
        {
            Table("Phases");

            Map(x => x.Name).Unique();
        }
    }
}
