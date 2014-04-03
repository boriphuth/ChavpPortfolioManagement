using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Test.Mappings
{
    using Cpm.Domains.Entities;

    internal class PhaseMap
        : EntityMap<Phase>
    {
        public PhaseMap()
        {
            Table("Phases");

            Map(x => x.Name).Unique();
        }
    }
}
