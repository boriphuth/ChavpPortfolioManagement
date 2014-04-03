using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Test.Mappings
{
    using Cpm.Domains.Entities;

    internal class MeasureEventMap
        : EntityMap<MeasureEvent>
    {
        public MeasureEventMap()
        {
            Table("MeasureEvents");

            Map(x => x.Type);
            Map(x => x.Start);
            Map(x => x.End);
            Map(x => x.Effort);
            Map(x => x.EffortUnit);
            Map(x => x.Value);
        }
    }
}
